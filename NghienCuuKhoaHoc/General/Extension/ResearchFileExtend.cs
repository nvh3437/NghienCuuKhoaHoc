using NghienCuuKhoaHoc.Data.Models;
using System.Text.RegularExpressions;

namespace NghienCuuKhoaHoc.General.Extension
{
    public static class ResearchFileExtend
    {
        public static string ToArrayJS(this List<ResearchFile>? ResearchFiles) 
        {
            string res = "new Array( ";
            foreach (var file in ResearchFiles)
            {
                string thumb = "";
                switch (file.FileExtend.ToLower())
                {
                    case "pptx": case "ppt": case "pptm": thumb = "/plugins/images/file/pp.png";
                        break;
                    case "xltx": case "xlsb": case "xlsm": case "xlsx": case "xls": thumb = "/plugins/images/file/ex.png";
                        break;
                    case "pdf": thumb = "/plugins/images/file/pdf.png";
                        break;
                    case "docx": case "doc": thumb = "/plugins/images/file/word.png";
                        break;
                    case "jpeg":
                    case "jpg":
                    case "png":
                    case "tiff ":
                    case "tif ":
                    case "gif":
                        thumb = file.File + "";
                        break;
                    default : thumb = "/plugins/images/file/file.png";
                        break;
                }
                string fullName = Regex.Replace(file.Name, @"[^a-zA-Z0-9.]", string.Empty);
                string fileName = fullName;
                if(fileName.Length > 25)
                {
                    fileName = fileName.Substring(0,25)+"...";
                }
                res += $@"new Array('{file.Id}','{fileName}','{file.File}','{thumb}','{fullName}'),";
            }
            res = res.Remove(res.Length - 1);
            res += ")";
            return res;
        }
        public static string GetThumb(this ResearchFile? ResearchFiles)
        {
            string thumb = "";
            switch (ResearchFiles.FileExtend.ToLower())
            {
                case "pptx":
                case "ppt":
                case "pptm":
                    thumb = "/plugins/images/file/pp.png";
                    break;
                case "xltx":
                case "xlsb":
                case "xlsm":
                case "xlsx":
                case "xls":
                    thumb = "/plugins/images/file/ex.png";
                    break;
                case "pdf":
                    thumb = "/plugins/images/file/pdf.png";
                    break;
                case "docx":
                case "doc":
                    thumb = "/plugins/images/file/word.png";
                    break;
                case "jpeg":
                case "jpg":
                case "png":
                case "tiff ":
                case "tif ":
                case "gif":
                    thumb = ResearchFiles.File + "";
                    break;
                default:
                    thumb = "/plugins/images/file/file.png";
                    break;
            }
            return thumb;
        }public static string GetName(this ResearchFile? ResearchFiles)
        {
            string fullName = Regex.Replace(ResearchFiles.Name, @"[^a-zA-Z0-9.]", string.Empty);
            string fileName = fullName;
            if (fileName.Length > 25)
            {
                fileName = fileName.Substring(0, 25) + "...";
            }
            return fileName;
        }

    }
}
