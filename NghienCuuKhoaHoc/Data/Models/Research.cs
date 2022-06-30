using NghienCuuKhoaHoc.General.Enum;

namespace NghienCuuKhoaHoc.Data.Models
{
    public class Research
    {
        public string Id { get; set; }
        public string? Subject { get; set; }
        public string? InstructorId { get; set; }
        public string? Field { get; set; }
        public Decimal Expense { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateExpired { get; set; }
        public ResearchStatus? Status { get; set; }
        public virtual Personal? Personal { get; set; }
        public virtual List<CouncilMember>? CouncilMembers { get; set; }
        public virtual ResearchAcceptance ResearchAcceptance { get; set; }
        public virtual List<ResearchFile>? ResearchFiles { get; set; }
    }
}
