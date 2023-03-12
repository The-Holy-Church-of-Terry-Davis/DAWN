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

    Log RootLogger = new Log("logs", "DAWN.log", false);
    Log Logger = new Log("logs", "DAWN.WebServer.cs.log");

    public WebServer(AppConfig conf)
    {
        
        RootLogger.Write("Made logger for WebServer.cs", "info");
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

            (byte[] buf, (string ct, int encoding)) = ResolveMappings(req.Url?.AbsolutePath ?? "");
            resp.ContentType = ct;
            resp.ContentEncoding = Solvers.SolveEncoding(encoding);
            resp.ContentLength64 = buf.LongLength;

            resp.OutputStream.Write(buf, 0, buf.Length);
            resp.Close();
        }
    }

    public (byte[], (string, int)) ResolveMappings(string req)
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
                (string t, int v) tp = Solvers.ContentTypeSolver(mp.filename.Split('.')[2]);
                Logger.Write($"Served \"{newstr}\" as \"{mp.filename}\"", "success");
                return (Builder.RetrieveFileResponse(mp.filename, tp.v), tp);
            }
        }

        try {
            (string t, int v) tp2 = Solvers.ContentTypeSolver(newstr?.Split('.')[1]);


            //resort to trying to send a file
            if(File.Exists(conf.RootDir + newstr))
            {
                return (Builder.RetrieveFileResponse(conf.RootDir + newstr, tp2.v), tp2);
            }

            //if all else failes it tries to parse the request into an existing html filename
            newstr = newstr + ".html";
            return (Builder.RetrieveFileResponse(conf.RootDir + newstr, tp2.v), tp2);
        } catch (Exception) {
            Logger.Write($"404: Could not find DAWN app, \"{newstr}\"", "error");
            if (File.Exists(conf.RootDir + "/error/404.html")) {
                return (Builder.RetrieveFileResponse(conf.RootDir + "/error/404.html", 2), ("text/html", 2));
            }
            else {
                return (Builder.RetrieveFileResponse(conf.RootDir + "/index.html", 2), ("text/html", 2));
                // if they dont have an index.html, then they shouldnt be doing web dev
            }
        }
    }
}