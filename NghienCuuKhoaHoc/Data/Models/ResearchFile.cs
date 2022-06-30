namespace NghienCuuKhoaHoc.Data.Models
{
    public class ResearchFile
    {
        public string Id { get; set; }
        public string ResearchId { get; set; }
        public string? Name { get; set; }
        public string? File { get; set; }
        public string? FileExtend { get; set; }
        public virtual Research Research { get; set; }
    }
}
