using System.Text;

namespace Dawn.Server;

public static class Solvers
{
    public static (string, int) ContentTypeSolver(string? extension)
    {
        switch(extension)
        {
            //Applications
            case "json":
            {
                return ("application/json", 1);
            }

            case "ai": case "ps": case "eps": //PostScript viewer, PostScript file, and Encapsulated PostScript
            {
                //ASCII
                return ("application/postscript", 1);
            }

            case "doc": //Microsoft Word document
            {
                //BINARY
                return ("application/msword", 0);
            }

            case "pdf":
            { 
                //BINARY
                return ("application/pdf", 0);
            }

            case "ppt": //PowerPoint file
            {
                //BINARY
                return ("application/powerpoint", 0);
            }

            case "rtf": //Rich Text Format (MSWord)
            {
                //ASCII
                return ("application/rtf", 1);
            }

            case "swf": //Shockwave Flash File
            {
                //BINARY
                return ("application/x-shockwave-flash", 0);
            }


            //Audio (ALL BINARY)
            case "aif": case "aiff":
            {
                //BINARY
                return ("audio/x-aiff", 0);
            }

            case "aifc": //Compressed AIFF file
            {
                //BINARY
                return ("audio/aifc", 0);
            }

            case "au": case "snd": //μ-law sound file and digitized sound file
            {
                //BINARY
                return ("audio/basic", 0);
            }

            case "mid": case "midi":
            {
                //BINARY
                return ("audio/x-midi", 0);
            }

            case "ra": case "ram": //RealAudio file and metafile
            {
                //BINARY
                return ("audio/x-pn-realaudio", 0);
            }

            case "wav":
            {
                //BINARY
                return ("audio/s-wav", 0);
            }

            case "mp2": case "mp3": case "mpa":
            {
                //BINARY
                return ("audio/mpeg", 0);
            }


            //Video (ALL BINARY)
            case "avi":
            {
                //BINARY
                return ("video/avi", 0);
            }

            case "mov": case "qt":
            {
                //BINARY
                return ("video/quicktime", 0);
            }

            case "movie": //Silicon Graphics movie
            {
                //BINARY
                return ("video/x-sgi-movie", 0);
            }

            case "mp4":
            {
                //BINARY
                return ("video/mp4", 0);
            }


            //Images (ALL BINARY)
            case "png":
            {
                //BINARY
                return ("image/x-png", 0);
            }

            case "jpg": case "jpeg": case "jpe": case "jfif": case "pjpeg": case "pjp":
            {
                //BINARY
                return ("image/jpeg", 0);
            }

            case "bmp":
            {
                //BINARY
                return ("image/x-MS-bmp", 0);
            }

            case "gif":
            {
                //BINARY
                return ("image/gif", 0);
            }

            case "pbm": //Portable bitmap image
            {
                //BINARY
                return ("image/x-portable-bitmap", 0);
            }

            case "pcd": //Kodak photo CD image
            {
                //BINARY
                return ("image/x-photo-cd", 0);
            }

            case "pic": //PICT image file
            {
                //BINARY
                return ("image/x-pict", 0);
            }

            case "tif": case "tiff": //TIFF image (requires external viewer)
            { 
                //BINARY
                return ("image/tiff", 0);
            }


            //Archives (ALL BINARY)
            case "tar":
            {
                //BINARY
                return ("x-tar", 0);
            }

            case "zip":
            {
                //BINARY
                return ("x-zip-compressed", 0);
            }

            case "gz":
            {
                //BINARY
                return ("x-gzip", 0);
            }

            case "sit": //Stuffit Archive
            {
                //BINARY
                return ("x-sit", 0);
            }

            case "sea": //Self-extracting Archive (Stuffit file)
            {
                //BINARY
                return ("x-sea", 0);
            }


            //Other
            case "exe":
            {
                //BINARY
                return ("x-msdownload", 0);
            }

            case "dcr": case "dir": case "dxr": //Shockwave files
            {
                //BINARY
                return ("x-director", 0);
            }

            case "pl":
            {
                //ASCII
                return ("x-perl", 1);
            }
            
            case "xxl": //Microsoft Excel file
            {
                //BINARY
                return ("vnd.mx-excel", 0);
            }


            //Text
            case "html": case "htm":
            {
                return ("text/html", 2);
            }

            case "js":
            {
                return ("text/javascript", 2);
            }

            case "css":
            {
                return ("text/css", 2);
            }

            case "rtx": //Rich Text Format (Microsoft Word)
            {
                return ("text/richtext", 2);
            }

            default:
            {
                return ("text/plain", 2);
            }
        }
    }

    public static Encoding? SolveEncoding(int indicator)
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