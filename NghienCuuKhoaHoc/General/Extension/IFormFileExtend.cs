using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.General.Extension
{
    public static class IFormFileExtend
    {
        public static async Task<string> SavePersonalImageAsync(this IFormFile formFile)
        {
            var folder = string.Format(@"wwwroot/plugins/images/users/");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);
            var filePath = Path.Combine(folder, fileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }
            return filePath.Substring(7);
        }
        public static async Task<ResearchFile> SaveResearchFileAsync(this IFormFile formFile, string ResearchId)
        {
            var folder = string.Format(@$"wwwroot/files/{ResearchId}/");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string fileExtension = Path.GetExtension(formFile.FileName);
            string fileName = Guid.NewGuid() + fileExtension;
            var filePath = Path.Combine(folder, fileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }
            return new ResearchFile()
            {
                Id = System.Guid.NewGuid().ToString("N"),
                File = filePath.Substring(7),
                Name = formFile.FileName,
                ResearchId = ResearchId,
                FileExtend = fileExtension.Substring(1),
            };
        }
    }
}
