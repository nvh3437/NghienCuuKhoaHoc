namespace NghienCuuKhoaHoc.Models
{
    public class PersonalDetailViewModel
    {
        public string Id { get; set; }
        public string? Avatar { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Birth { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Literacy { get; set; }
        public string? Position { get; set; }
        public List<ResearchDetailViewModel>? Researches { get; set; }
    }
}
