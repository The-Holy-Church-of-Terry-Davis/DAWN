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

    public WebServer(AppConfig conf)
    {
        foreach(string prefix in conf.Prefixes)
        {
            //Log.Task("Adding prefixes to the listener");
            listener.Prefixes.Add(prefix);
            //Log.Success($"Added, \"{prefix}\" prefix to the listener");
        }

        if(!conf.RootDir.EndsWith('/'))
        {
            conf.RootDir = conf.RootDir + '/';
        }

        this.conf = conf;

        //Log.Task("Starting lisenter");
        listener.Start();
        //Log.Success("Listenter started");

        Thread t = new Thread(new ThreadStart(ServerHandle));
        //Log.Task("Starting thread");
        t.Start();
        //Log.Success("Thread started");
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
        //Log.Info("ResolveMappings called");
        //make sure there is no null
        if(req == null)
        {
            //Log.Warn("null recieved, returning index.html");
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
                (string t, int v) tp = Solvers.ContentTypeSolver(mp.filename.Split('.')[2]);
                return (Builder.RetrieveFileResponse(mp.filename, tp.v), tp);
            }
        }

        (string t, int v) tp2 = Solvers.ContentTypeSolver(newstr.Split('.')[1]);

        //resort to trying to send a file
        if(File.Exists(conf.RootDir + newstr))
        {
            return (Builder.RetrieveFileResponse(conf.RootDir + newstr, tp2.v), tp2);
        }

        //if all else failes it tries to parse the request into an existing html filename
        newstr = newstr + ".html";
        return (Builder.RetrieveFileResponse(conf.RootDir + newstr, tp2.v), tp2);
    }
}