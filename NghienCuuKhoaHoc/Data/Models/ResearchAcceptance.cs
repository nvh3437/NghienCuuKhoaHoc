using NghienCuuKhoaHoc.General.Enum;

namespace NghienCuuKhoaHoc.Data.Models
{
    public class ResearchAcceptance
    {
        public string ResearchId { get; set; }
        public double? Score { get; set; }
        public AcceptanceRate? Rating { get; set; }
        public AcceptanceStatus? Acceptance { get; set; }
        public virtual Research Research { get; set; }
    }
}
