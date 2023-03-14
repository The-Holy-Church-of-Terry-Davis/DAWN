using System.Text;

namespace Dawn.Server;

internal static class Solvers
{
    internal static SolverContentCtx ContentTypeSolver(string? extension)
    {
        switch(extension)
        {
            //Applications
            case "json":
            {
                return new("application/json", 1);
            }

            case "wasm":
            {
                return new("application/wasm", 0);
            }

            case "ai": case "ps": case "eps": //PostScript viewer, PostScript file, and Encapsulated PostScript
            {
                //ASCII
                return new("application/postscript", 1);
            }

            case "doc": //Microsoft Word document
            {
                //BINARY
                return new("application/msword", 0);
            }

            case "pdf":
            { 
                //BINARY
                return new("application/pdf", 0);
            }

            case "ppt": //PowerPoint file
            {
                //BINARY
                return new("application/powerpoint", 0);
            }

            case "rtf": //Rich Text Format (MSWord)
            {
                //ASCII
                return new("application/rtf", 1);
            }

            case "swf": //Shockwave Flash File
            {
                //BINARY
                return new("application/x-shockwave-flash", 0);
            }


            //Audio (ALL BINARY)
            case "aif": case "aiff":
            {
                //BINARY
                return new("audio/x-aiff", 0);
            }

            case "aifc": //Compressed AIFF file
            {
                //BINARY
                return new("audio/aifc", 0);
            }

            case "au": case "snd": //μ-law sound file and digitized sound file
            {
                //BINARY
                return new("audio/basic", 0);
            }

            case "mid": case "midi":
            {
                //BINARY
                return new("audio/x-midi", 0);
            }

            case "ra": case "ram": //RealAudio file and metafile
            {
                //BINARY
                return new("audio/x-pn-realaudio", 0);
            }

            case "wav":
            {
                //BINARY
                return new("audio/s-wav", 0);
            }

            case "mp2": case "mp3": case "mpa":
            {
                //BINARY
                return new("audio/mpeg", 0);
            }


            //Video (ALL BINARY)
            case "avi":
            {
                //BINARY
                return new("video/avi", 0);
            }

            case "mov": case "qt":
            {
                //BINARY
                return new("video/quicktime", 0);
            }

            case "movie": //Silicon Graphics movie
            {
                //BINARY
                return new("video/x-sgi-movie", 0);
            }

            case "mp4":
            {
                //BINARY
                return new("video/mp4", 0);
            }


            //Images (ALL BINARY)
            case "png":
            {
                //BINARY
                return new("image/x-png", 0);
            }

            case "jpg": case "jpeg": case "jpe": case "jfif": case "pjpeg": case "pjp":
            {
                //BINARY
                return new("image/jpeg", 0);
            }

            case "bmp":
            {
                //BINARY
                return new("image/x-MS-bmp", 0);
            }

            case "gif":
            {
                //BINARY
                return new("image/gif", 0);
            }

            case "pbm": //Portable bitmap image
            {
                //BINARY
                return new("image/x-portable-bitmap", 0);
            }

            case "pcd": //Kodak photo CD image
            {
                //BINARY
                return new("image/x-photo-cd", 0);
            }

            case "pic": //PICT image file
            {
                //BINARY
                return new("image/x-pict", 0);
            }

            case "tif": case "tiff": //TIFF image (requires external viewer)
            { 
                //BINARY
                return new("image/tiff", 0);
            }


            //Archives (ALL BINARY)
            case "tar":
            {
                //BINARY
                return new("x-tar", 0);
            }

            case "zip":
            {
                //BINARY
                return new("x-zip-compressed", 0);
            }

            case "gz":
            {
                //BINARY
                return new("x-gzip", 0);
            }

            case "sit": //Stuffit Archive
            {
                //BINARY
                return new("x-sit", 0);
            }

            case "sea": //Self-extracting Archive (Stuffit file)
            {
                //BINARY
                return new("x-sea", 0);
            }


            //Other
            case "exe":
            {
                //BINARY
                return new("x-msdownload", 0);
            }

            case "dcr": case "dir": case "dxr": //Shockwave files
            {
                //BINARY
                return new("x-director", 0);
            }

            case "pl":
            {
                //ASCII
                return new("x-perl", 1);
            }
            
            case "xxl": //Microsoft Excel file
            {
                //BINARY
                return new("vnd.mx-excel", 0);
            }


            //Text
            case "html": case "htm":
            {
                return new("text/html", 2);
            }

            case "js":
            {
                return new("text/javascript", 2);
            }

            case "css":
            {
                return new("text/css", 2);
            }

            case "rtx": //Rich Text Format (Microsoft Word)
            {
                return new("text/richtext", 2);
            }

            default:
            {
                return new("text/plain", 2);
            }
        }
    }

    internal static Encoding? SolveEncoding(int indicator)
    {
        switch(indicator)
        {
            case 0:
            {
                return null;
            }

            case 1:
            {
                return Encoding.ASCII;
            }

            case 2:
            {
                return Encoding.UTF8;
            }
        }

        return Encoding.UTF8;
    }
}