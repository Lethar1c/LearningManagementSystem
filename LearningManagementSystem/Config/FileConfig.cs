namespace LearningManagementSystem.Config
{
    public class FileInfo
    {
        public List<string> Extensions { get; set; } = [];
        public string MIMEType { get; set; } = "application/octet-stream";
        public int MaxSize = 5000000;
    }
    public static class FileConfig
    {
        const int KB = 1024;
        const int MB = 1024 * KB;
        const int GB = 1024 * MB;
        public static readonly FileInfo APNG = new FileInfo
        {
            Extensions = [".apng"],
            MIMEType = "image/apng",
            MaxSize = 5 * MB,
        };
        public static readonly FileInfo AVIF = new FileInfo
        {
            Extensions = [".avif"],
            MIMEType = "image/avif",
            MaxSize = 5 * MB,
        };
        public static readonly FileInfo GIF = new FileInfo
        {
            Extensions = [".gif"],
            MIMEType = "image/gif",
            MaxSize = 5 * MB,
        };
        public static readonly FileInfo JPEG = new FileInfo
        {
            Extensions = [".jpg", ".jpeg", ".jfif", ".pjpeg", ".pjp"],
            MIMEType = "image/jpeg",
            MaxSize = 5 * MB,
        };
        public static readonly FileInfo PNG = new FileInfo
        {
            Extensions = [".png"],
            MIMEType = "image/png",
            MaxSize = 5 * MB,
        };
        public static readonly FileInfo SVG = new FileInfo
        {
            Extensions = [".svg"],
            MIMEType = "image/svg+xml",
            MaxSize = 5 * MB,
        };
        public static readonly FileInfo WEBP = new FileInfo
        {
            Extensions = [".webp"],
            MIMEType = "image/webp",
            MaxSize = 5 * MB,
        };
        public static readonly FileInfo AAC = new FileInfo
        {
            Extensions = [".aac"],
            MIMEType = "audio/aac",
            MaxSize = 10 * MB,
        };
        public static readonly FileInfo AVI = new FileInfo
        {
            Extensions = [".avi"],
            MIMEType = "video/x-msvideo",
            MaxSize = 5 * MB,
        };
        public static readonly FileInfo MP3 = new FileInfo
        {
            Extensions = [".mp3"],
            MIMEType = "audio/mpeg",
            MaxSize = 10 * MB,
        };
        public static readonly FileInfo MP4 = new FileInfo
        {
            Extensions = [".mp4"],
            MIMEType = "video/mp4",
            MaxSize = 1 * GB,
        };
        public static readonly FileInfo MPEG = new FileInfo
        {
            Extensions = [".mpeg"],
            MIMEType = "video/mpeg",
            MaxSize = 1 * GB,
        };
        public static readonly FileInfo PDF = new FileInfo
        {
            Extensions = [".pdf"],
            MIMEType = "application/pdf",
            MaxSize = 100 * MB,
        };

        private static readonly List<FileInfo> _extentions =
            [APNG, AVIF, GIF, JPEG, PNG, SVG, WEBP, AAC, AVI, MP3, MP4, MPEG, PDF];

        public static List<string> GetAllowedExtentions()
        {
            List<string> result = new(_extentions.Count * 2);
            foreach (FileInfo f in _extentions)
            {
                result.AddRange(f.Extensions);
            }
            return result;
        }

        public static FileInfo? GetFileInfo(string extension)
        {
            foreach (FileInfo f in _extentions)
            {
                if (f.Extensions.Contains(extension))
                {
                    return f;
                }
            }
            return null;
        }
    }
}
