using System.Net;
using Dawn.Types;
using Dawn.Decorators;
using Dawn.Logger;
using Dawn;

namespace Dawn.Server;

public class WebServer
{
    public HttpListener listener = new();
    public AppConfig conf { get; set; }
    public RestrictionConfig rconf { get; set; }

    Log Logger = new Log("logs", "DAWN.WebServer.cs.log");

    public WebServer(AppConfig conf, RestrictionConfig r)
    {
        rconf = r;

        foreach(string prefix in conf.Prefixes)
        {
            Logger.Write("Adding prefixes to the listener", "task");
            listener.Prefixes.Add(prefix);
            Logger.Write($"Added, \"{prefix}\" prefix to the listener", "success");
        }

        if(!conf.RootDir.EndsWith('/'))
        {
            conf.RootDir = conf.RootDir + '/';
        }

        this.conf = conf;
        
        Logger.Write("Starting lisenter", "task");
        listener.Start();
        Logger.Write("Listenter started", "success");

        Thread t = new Thread(new ThreadStart(ServerHandle));
        Logger.Write("Starting thread", "task");
        t.Start();
        Logger.Write("Thread started", "success");

        Logger.Write($"Creating, \"{conf.RootDir}\"", "task");
        Directory.CreateDirectory(conf.RootDir);
        Logger.Write($"Created, \"{conf.RootDir}\"", "success");
    }

    public void ServerHandle()
    {
        while(true)
        {
            HttpListenerContext ctx = listener.GetContext();
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

    public WebServerResponseInfo ResolveMappings(string req)
    {

        //make sure there is no null
        if(req == null)
        {
            Logger.Write("null recieved, returning index.html", "warn");
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
                Logger.Write($"Route, \"{newstr}\" requested", "task");
                SolverContentCtx tp = Solvers.ContentTypeSolver(mp.filename.Split('.')[2]);
                Logger.Write($"Served \"{newstr}\" as \"{mp.filename}\"", "success");
                return new(Builder.RetrieveFileResponse(mp.filename, tp.buildertype), tp, 200);
            }
        }

        try 
        {
            if (newstr == null) {
                Logger.Write("null was requested", "warn");
            } else {
                Logger.Write($"\"{newstr}\" was requested", "task");
            }
            SolverContentCtx tp2 = Solvers.ContentTypeSolver(newstr?.Split('.')[1]);


            //resort to trying to send a file
            if(File.Exists(conf.RootDir + newstr?[1..])) // added [1..] because without it would be: ./RootDir//file.extension. Now it is: ./RootDir/file.extension
            {
                Logger.Write($"Fetched {conf.RootDir + newstr?[1..]}", "success");
                return new(Builder.RetrieveFileResponse(conf.RootDir + newstr, tp2.buildertype), tp2, 200);
            }

            //if all else failes it tries to parse the request into an existing html filename
            if ( newstr?[1..] != null) 
            {
                newstr = newstr[1..];
            }
            return new(Builder.RetrieveFileResponse(conf.RootDir + newstr, tp2.buildertype), tp2, 200);
        } catch (Exception) 
        {
            Logger.Write($"404: Could not find DAWN app, \"{newstr}\"", "error");
            if (File.Exists(conf.RootDir + "/error/404.html")) 
            {
                return new(Builder.RetrieveFileResponse(conf.RootDir + "/error/404.html", 2), new("text/html", 2), 404);
            }
            else {
                return new(Builder.RetrieveFileResponse(conf.RootDir + "/index.html", 2), new("text/html", 2), 404);
                // if they dont have an index.html, then they shouldnt be doing web dev
            }
        }
    }
}