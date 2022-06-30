namespace NghienCuuKhoaHoc.Data.Models
{
    public class Department
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual List<Personal>? Personals { get; set; }

    }
}
