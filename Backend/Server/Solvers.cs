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
                //ASCII
                return "application/postscript";
            }

            case "doc": //Microsoft Word document
            {
                //BINARY
                return "application/msword";
            }

            case "pdf":
            { 
                //BINARY
                return "application/pdf";
            }

            case "ppt": //PowerPoint file
            {
                //BINARY
                return "application/powerpoint";
            }

            case "rtf": //Rich Text Format (MSWord)
            {
                //ASCII
                return "application/rtf";
            }

            case "swf": //Shockwave Flash File
            {
                //BINARY
                return "application/x-shockwave-flash";
            }


            //Audio (ALL BINARY)
            case "aif": case "aiff":
            {
                //BINARY
                return "audio/x-aiff";
            }

            case "aifc": //Compressed AIFF file
            {
                //BINARY
                return "audio/aifc";
            }

            case "au": case "snd": //μ-law sound file and digitized sound file
            {
                //BINARY
                return "audio/basic";
            }

            case "mid": case "midi":
            {
                //BINARY
                return "audio/x-midi";
            }

            case "ra": case "ram": //RealAudio file and metafile
            {
                //BINARY
                return "audio/x-pn-realaudio";
            }

            case "wav":
            {
                //BINARY
                return "audio/s-wav";
            }

            case "mp2": case "mp3": case "mpa":
            {
                //BINARY
                return "audio/mpeg";
            }


            //Video (ALL BINARY)
            case "avi":
            {
                //BINARY
                return "video/avi";
            }

            case "mov": case "qt":
            {
                //BINARY
                return "video/quicktime";
            }

            case "movie": //Silicon Graphics movie
            {
                //BINARY
                return "video/x-sgi-movie";
            }

            case "mp4":
            {
                //BINARY
                return "video/mp4";
            }


            //Images (ALL BINARY)
            case "png":
            {
                //BINARY
                return "image/x-png";
            }

            case "jpg": case "jpeg": case "jpe": case "jfif": case "pjpeg": case "pjp":
            {
                //BINARY
                return "image/jpeg";
            }

            case "bmp":
            {
                //BINARY
                return "image/x-MS-bmp";
            }

            case "gif":
            {
                //BINARY
                return "image/gif";
            }

            case "pbm": //Portable bitmap image
            {
                //BINARY
                return "image/x-portable-bitmap";
            }

            case "pcd": //Kodak photo CD image
            {
                //BINARY
                return "image/x-photo-cd";
            }

            case "pic": //PICT image file
            {
                //BINARY
                return "image/x-pict";
            }

            case "tif": case "tiff": //TIFF image (requires external viewer)
            { 
                //BINARY
                return "image/tiff";
            }


            //Archives (ALL BINARY)
            case "tar":
            {
                //BINARY
                return "x-tar";
            }

            case "zip":
            {
                //BINARY
                return "x-zip-compressed";
            }

            case "gz":
            {
                //BINARY
                return "x-gzip";
            }

            case "sit": //Stuffit Archive
            {
                //BINARY
                return "x-sit";
            }

            case "sea": //Self-extracting Archive (Stuffit file)
            {
                //BINARY
                return "x-sea";
            }


            //Other
            case "exe":
            {
                //BINARY
                return "x-msdownload";
            }

            case "dcr": case "dir": case "dxr": //Shockwave files
            {
                //BINARY
                return "x-director";
            }

            case "pl":
            {
                //ASCII
                return "x-perl";
            }
            
            case "xxl": //Microsoft Excel file
            {
                //BINARY
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