namespace NghienCuuKhoaHoc.Data.Models
{
    public class Personal
    {
        public string Id { get; set; }
        public string? Avatar { get; set; }
        public string? Name { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Birth { get; set; }
        public string? DepartmentId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Literacy { get; set; }
        public string? Position { get; set; }
        public virtual List<Research>? Researches { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<CouncilMember>? CouncilMembers { get; set; }

    }
}
