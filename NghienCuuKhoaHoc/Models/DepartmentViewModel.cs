using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace NghienCuuKhoaHoc.Models
{
    public class DepartmentViewModel
    {
        [Required(ErrorMessage = "là bắt buộc")]
        [RegularExpression("[A-Za-z0-9]*",ErrorMessage ="là chữ và số")]
        [StringLength(128, ErrorMessage = "phải trong phạm vi {2} - {1} Ký tự.", MinimumLength = 4)]

        [Display(Name ="Mã Khoa")]
        public string Id { get; set; }
        
        [Required(ErrorMessage = "là bắt buộc")]
        [StringLength(128, ErrorMessage = "phải nhỏ hơn {1} Ký tự.")]
        [Display(Name ="Tên Khoa")]
        public string Name { get; set; }
        public string? CreatedDate { get; set; }
        public List<DepartmentViewModel>? Departments { get; set; }
        public string? FindKeyword { get; set; }
    }
}
