using NghienCuuKhoaHoc.General.Enum;

namespace NghienCuuKhoaHoc.Data.Models
{
    public class CouncilMember
    {
        public string? ResearchId { get; set; }
        public string? MemberId { get; set; }
        public PositionCouncil Position { get; set; }
        public virtual Research? Research { get; set; }
        public virtual Personal? Personal { get; set; }
    }
}
