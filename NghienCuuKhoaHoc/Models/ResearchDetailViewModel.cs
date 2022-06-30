using NghienCuuKhoaHoc.Data.Models;

namespace NghienCuuKhoaHoc.Models
{
    public class ResearchDetailViewModel
    {
        public string Id { get; set; }
        public string? Subject { get; set; }
        public string? InstructorId { get; set; }
        public string? Instructor { get; set; }
        public string? Field { get; set; }
        public Decimal? Expense { get; set; }
        public string? DateStarted { get; set; }
        public string? DateExpired { get; set; }
        public General.Enum.ResearchStatus? Status { get; set; }
        public List<ResearchFile>? ResearchFiles { get; set; }
        public string? Chairman { get; set; }
        public string? Commissioner1 { get; set; }
        public string? Commissioner2 { get; set; }
        public string? Secretary { get; set; }
        public double? Score { get; set; }
        public General.Enum.AcceptanceStatus? Acceptance { get; set; }
        public General.Enum.AcceptanceRate? Rate { get; set; }

    }
}
