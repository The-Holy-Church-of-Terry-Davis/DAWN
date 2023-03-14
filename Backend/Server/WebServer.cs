using System.Net;
using Dawn.Types;
using Dawn.Authentication;
using Dawn.Decorators;
using Dawn.Logger;
using Dawn;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace Dawn.Server;

internal class WebServer
{
    private HttpListener listener = new();
    public AppConfig conf { get; set; }
    public RestrictionConfig rconf { get; set; }
    public SSLConfig? sslconf { get; set; }
    private List<AuthenticationBearer> AuthenticatedAddrs = new();

    Log Logger = new Log("logs", "DAWN.WebServer.cs.log");

    internal WebServer(AppConfig conf, RestrictionConfig r, SSLConfig sslcfg)
    {
        rconf = r;

        foreach(string prefix in conf.Prefixes)
        {
            Logger.Write("Adding prefixes to the listener", LogLevel.TASK);
            listener.Prefixes.Add(prefix);
            Logger.Write($"Added, \"{prefix}\" prefix to the listener", LogLevel.SUCCESS);
        }

        if(!conf.RootDir.EndsWith('/'))
        {
            conf.RootDir = conf.RootDir + '/';
        }

        this.conf = conf;
        sslconf = sslcfg;
        
        Logger.Write("Starting lisenter", LogLevel.TASK);
        listener.Start();
        Logger.Write("Listenter started", LogLevel.SUCCESS);

        Thread t = new Thread(new ThreadStart(ServerHandle));
        Logger.Write("Starting thread", LogLevel.TASK);
        t.Start();
        Logger.Write("Thread started", LogLevel.SUCCESS);

        Logger.Write($"Creating, \"{conf.RootDir}\"", LogLevel.TASK);
        Directory.CreateDirectory(conf.RootDir);
        Logger.Write($"Created, \"{conf.RootDir}\"", LogLevel.SUCCESS);
    }

    internal void ServerHandle()
    {
        while(true)
        {
            HttpListenerContext ctx = listener.GetContext();
            
            if(ctx.Request.IsSecureConnection)
            {
                /*
                    ^^ The above code does not work
                    and I do not know why... if anyone
                    sees a fix please contact one of the
                    maintainers of this project!!! We
                    could use the help!
                */

                ResolveSSL(ctx); //I'm fairly sure this function works fine
            } else 
            {
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                WebServerResponseInfo rinf = ResolveMappings(req.Url?.AbsolutePath ?? "");
                resp.ContentType = rinf.ctx.contenttype;
                resp.ContentEncoding = Solvers.SolveEncoding(rinf.ctx.buildertype);
                resp.ContentLength64 = rinf.data.LongLength;
                resp.StatusCode = rinf.code;

                resp.OutputStream.Write(rinf.data, 0, rinf.data.Length);
                resp.Close();
            }
        }
    }

    internal void ResolveSSL(HttpListenerContext ctx)
    {
        HttpListenerRequest req = ctx.Request;
        HttpListenerResponse resp = ctx.Response;

        X509Certificate2 cert = new(sslconf!.filename);
        RSACryptoServiceProvider pubKey = (RSACryptoServiceProvider)cert.GetRSAPublicKey()!;

        resp.ContentType = "application/x-x509-ca-cert";
        resp.AddHeader("Content-Disposition", "attachment; filename=certificate.crt");
        resp.OutputStream.Write(cert.Export(X509ContentType.Cert), 0, cert.Export(X509ContentType.Cert).Length);
        resp.Close();
    }

    internal WebServerResponseInfo ResolveMappings(string req)
    {
        //make sure there is no null
        if(req == null)
        {
            Logger.Write("null recieved, returning index.html", LogLevel.WARN);
            req = "index.html";
        }

        string newstr = req;

        //try defaults which is the mappings
        foreach(Mapping mp in conf.Mappings)
        {

            //make sure the path is C# readable
            if(!mp.request_path.StartsWith('/'))
            {

                mp.request_path = '/' + mp.request_path;
            }

            if(newstr == mp.request_path)
            {
                if(rconf.CanAccess(mp.filename))
                {
                    Logger.Write($"Route, \"{newstr}\" requested", LogLevel.TASK);
                    SolverContentCtx tp = Solvers.ContentTypeSolver(mp.filename.Split('.')[2]);
                    Logger.Write($"Served \"{newstr}\" as \"{mp.filename}\"", LogLevel.SUCCESS);
                    return new(Builder.RetrieveFileResponse(mp.filename, tp.buildertype), tp, 200);
                } else if(!rconf.CanAccess(mp.filename))
                {
                    return new(System.Text.Encoding.UTF8.GetBytes("<p>Error 403</p>"), new("text/html", 2), 403);
                }

                if (File.Exists(conf.RootDir + "/error/404.html")) 
                {
                    Logger.Write("404 error return", LogLevel.ERROR);
                    return new(Builder.RetrieveFileResponse(conf.RootDir + "/error/404.html", 2), new("text/html", 2), 404);
                }
                else 
                {
                    Logger.Write("404 error return", LogLevel.ERROR);
                    return new(Builder.RetrieveFileResponse(conf.RootDir + "/index.html", 2), new("text/html", 2), 404);
                }
            }
        }

        try 
        {
            if (newstr == null) {
                Logger.Write("null was requested", LogLevel.WARN);
            } else {
                Logger.Write($"\"{newstr}\" was requested", LogLevel.TASK);
            }
            SolverContentCtx tp2 = Solvers.ContentTypeSolver(newstr?.Split('.')[1]);

            //resort to trying to send a file
            if(File.Exists(conf.RootDir + newstr?[1..])) // added [1..] because without it would be: ./RootDir//file.extension. Now it is: ./RootDir/file.extension
            {
                //check restrictions against file if it exists
                if(rconf.CanAccess(conf.RootDir + newstr?[1..]))
                {
                    Logger.Write($"Fetched {conf.RootDir + newstr?[1..]}", LogLevel.SUCCESS);
                    return new(Builder.RetrieveFileResponse(conf.RootDir + newstr, tp2.buildertype), tp2, 200);
                } else if(!rconf.CanAccess(conf.RootDir + newstr?[1..]))
                {
                    Logger.Write("403 error return", LogLevel.ERROR);
                    return new(System.Text.Encoding.UTF8.GetBytes("<p>Error 403</p>"), new("text/html", 2), 403);
                }
            } else if(!File.Exists(conf.RootDir + newstr?[1..]))
            {
                Logger.Write("404 error return", LogLevel.ERROR);

                if (File.Exists(conf.RootDir + "/error/404.html")) 
                {
                    return new(Builder.RetrieveFileResponse(conf.RootDir + "/error/404.html", 2), new("text/html", 2), 404);
                }
                else 
                {
                    return new(Builder.RetrieveFileResponse(conf.RootDir + "/index.html", 2), new("text/html", 2), 404);
                }
            }

            //if all else failes it tries to parse the request into an existing html filename
            if ( newstr?[1..] != null) 
            {
                newstr = newstr[1..];
            }

            //Check restrictions under last resort return
           if(rconf.CanAccess(conf.RootDir + newstr))
           {
                return new(Builder.RetrieveFileResponse(conf.RootDir + newstr, tp2.buildertype), tp2, 200);
           } else {
                if(!rconf.CanAccess(conf.RootDir + newstr))
                {
                    Logger.Write("403 error return", LogLevel.ERROR);   
                    return new(System.Text.Encoding.UTF8.GetBytes("<p>Error 403</p>"), new("text/html", 2), 403);
                }

                if (File.Exists(conf.RootDir + "/error/404.html")) 
                {
                    //CHECK IF USER CAN ACCESS SO WE CAN RETURN THE CORRECT CODE
                    Logger.Write("404 error return", LogLevel.ERROR);
                    return new(Builder.RetrieveFileResponse(conf.RootDir + "/error/404.html", 2), new("text/html", 2), 404);
                }
                else
                {
                    Logger.Write("You do not know what you are doing!", LogLevel.ERROR);
                    return new(Builder.RetrieveFileResponse(conf.RootDir + "/index.html", 2), new("text/html", 2), 404);
                }
           }
        } catch (Exception) 
        {
            Logger.Write($"404: Could not find DAWN app, \"{newstr}\"", LogLevel.ERROR);
            if (File.Exists(conf.RootDir + "/error/404.html")) 
            {
                Logger.Write("404 error return", LogLevel.ERROR);
                return new(Builder.RetrieveFileResponse(conf.RootDir + "/error/404.html", 2), new("text/html", 2), 404);
            }
            else 
            {
                return new(Builder.RetrieveFileResponse(conf.RootDir + "/index.html", 2), new("text/html", 2), 404);
                // if they dont have an index.html, then they shouldnt be doing web dev
            }
        }
    }
}