namespace Dawn.Server;

public static class Solvers
{
    public static string ContentTypeSolver(string? extension)
    {
        switch(extension)
        {
            //Applications
            case "json":
            {
                return "application/json";
            }

            case "ai": case "ps": case "eps": //PostScript viewer, PostScript file, and Encapsulated PostScript
            {
                return "application/postscript";
            }

            case "doc": //Microsoft Word document
            {
                return "application/msword";
            }

            case "pdf":
            { 
                return "application/pdf";
            }

            case "ppt": //PowerPoint file
            {
                return "application/powerpoint";
            }

            case "rtf": //Rich Text Format (MSWord)
            {
                return "application/rtf";
            }

            case "swf": //Shockwave Flash File
            {
                return "application/x-shockwave-flash";
            }


            //Audio
            case "aif": case "aiff":
            {
                return "audio/x-aiff";
            }

            case "aifc": //Compressed AIFF file
            {
                return "audio/aifc";
            }

            case "au": case "snd": //μ-law sound file and digitized sound file
            {
                return "audio/basic";
            }

            case "mid": case "midi":
            {
                return "audio/x-midi";
            }

            case "ra": case "ram": //RealAudio file and metafile
            {
                return "audio/x-pn-realaudio";
            }

            case "wav":
            {
                return "audio/s-wav";
            }

            case "mp2": case "mp3": case "mpa":
            {
                return "audio/mpeg";
            }


            //Video
            case "avi":
            {
                return "video/avi";
            }

            case "mov": case "qt":
            {
                return "video/quicktime";
            }

            case "movie": //Silicon Graphics movie
            {
                return "video/x-sgi-movie";
            }

            case "mp4":
            {
                return "video/mp4";
            }


            //Images
            case "png":
            {
                return "image/x-png";
            }

            case "jpg": case "jpeg": case "jpe": case "jfif": case "pjpeg": case "pjp":
            {
                return "image/jpeg";
            }

            case "bmp":
            {
                return "image/x-MS-bmp";
            }

            case "gif":
            {
                return "image/gif";
            }

            case "pbm": //Portable bitmap image
            {
                return "image/x-portable-bitmap";
            }

            case "pcd": //Kodak photo CD image
            {
                return "image/x-photo-cd";
            }

            case "pic": //PICT image file
            {
                return "image/x-pict";
            }

            case "tif": case "tiff": //TIFF image (requires external viewer)
            { 
                return "image/tiff";
            }


            //Archives
            case "tar":
            {
                return "x-tar";
            }

            case "zip":
            {
                return "x-zip-compressed";
            }

            case "gz":
            {
                return "z-gzip";
            }

            case "sit": //Stuffit Archive
            {
                return "x-sit";
            }

            case "sea": //Self-extracting Archive (Stuffit file)
            {
                return "x-sea";
            }


            //Other
            case "exe":
            {
                return "x-msdownload";
            }

            case "dcr": case "dir": case "dxr": //Shockwave files
            {
                return "x-director";
            }

            case "pl":
            {
                return "x-pearl";
            }
            
            case "xxl": //Microsoft Excel file
            {
                return "vnd.mx-excel";
            }


            //Text
            case "txt":
            {
                return "text/plain";
            }

            case "js":
            {
                return "text/javascript";
            }

            case "css":
            {
                return "text/css";
            }

            case "rtx": //Rich Text Format (Microsoft Word)
            {
                return "text/richtext";
            }

            default:
            {
                return "text/html";
            }
        }
    }
}