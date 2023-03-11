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

            (byte[] buf, string ct) = ResolveMappings(req.Url?.AbsolutePath ?? "");
            resp.ContentType = ct;
            resp.ContentEncoding = System.Text.Encoding.UTF8;
            resp.ContentLength64 = buf.LongLength;

            resp.OutputStream.Write(buf, 0, buf.Length);
            resp.Close();
        }
    }

    public (byte[], string) ResolveMappings(string req)
    {   
        //try defaults which is the mappings
        foreach(Mapping mp in conf.Mappings)
        {
            //make sure the path is C# readable
            if(!mp.request_path.StartsWith('/'))
            {
                mp.request_path = '/' + mp.request_path;
            }

            if(req == mp.request_path)
            {
                return (Builder.BuildHtmlResponse(mp.filename), Solvers.ContentTypeSolver(mp.filename.Split('.')[1]));
            }
        }

        //Check if unsepcified file exists
        if(File.Exists(conf.RootDir + req))
        {
            return (Builder.BuildHtmlResponse(conf.RootDir + req), Solvers.ContentTypeSolver(req?.Split('.')[1]));
        }

        //resort to trying to send a file
        if(req.EndsWith(".html"))
        {
            return (Builder.BuildHtmlResponse(conf.RootDir + req), Solvers.ContentTypeSolver(req?.Split('.')[1]));
        }

        req = req + ".html";
        return (Builder.BuildHtmlResponse(conf.RootDir + req), Solvers.ContentTypeSolver(req?.Split('.')[1]));
    }
}