using System.Net;
using Dawn.Types;
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
            listener.Prefixes.Add(prefix);
        }

        if(!conf.RootDir.EndsWith('/'))
        {
            conf.RootDir = conf.RootDir + '/';
        }

        this.conf = conf;

        listener.Start();
        Thread t = new Thread(new ThreadStart(ServerHandle));
        t.Start();
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
        if(newstr.EndsWith(".html") || File.Exists(conf.RootDir + newstr))
        {
            return (Builder.RetrieveFileResponse(conf.RootDir + newstr, tp2.v), tp2);
        }

        newstr = newstr + ".html";
        return (Builder.RetrieveFileResponse(conf.RootDir + newstr, tp2.v), tp2);
    }
}