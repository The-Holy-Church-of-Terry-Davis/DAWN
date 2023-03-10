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
    }

    public void ServerHandle()
    {
        while(true)
        {
            HttpListenerContext ctx = listener.GetContext();
            HttpListenerRequest req = ctx.Request;
            HttpListenerResponse resp = ctx.Response;

            resp.ContentType = Solvers.ContentTypeSolver();
        }
    }

    public byte[] ResolveMappings(string req)
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
                return Builder.BuildHtmlResponse(mp.filename);
            }
        }

        //resort to trying to send a file
        return Builder.BuildHtmlResponse(req);
    }
}