using NghienCuuKhoaHoc.Data.Models;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace NghienCuuKhoaHoc.Models
{
    public class PersonalViewModel
    {
        [Required(ErrorMessage = "là bắt buộc")]
        [RegularExpression("[A-Za-z0-9]*",ErrorMessage ="là chữ và số")]
        [StringLength(12, ErrorMessage = "phải trong phạm vi {2} - {1} Ký tự.", MinimumLength = 4)]
        [Display(Name ="Mã giảng viên")]
        public string Id { get; set; }
        
        [Required(ErrorMessage = "là bắt buộc")]
        [StringLength(256, ErrorMessage = "phải nhỏ hơn {1} Ký tự.")]
        [Display(Name ="Tên giảng viên")]
        public string Name { get; set; }
        public string? Avatar { get; set; }
        public IFormFile? NewAvatar { get; set; }
        public string? Gender { get; set; }
        public string? Birth { get; set; }

        [Required(ErrorMessage = "là bắt buộc")]
        public string? DepartmentId { get; set; }
        public string? Department { get; set; }

        [EmailAddress(ErrorMessage = "phải là email")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "phải là số điện thoại")]
        public string? PhoneNumber { get; set; }
        [StringLength(128, ErrorMessage = "phải nhỏ hơn {1} Ký tự.")]
        public string? Literacy { get; set; }
        [StringLength(128, ErrorMessage = "phải nhỏ hơn {1} Ký tự.")]
        public string? Position { get; set; }
        public IPagedList<PersonalViewModel>? Personals { get; set; }
        public int Page { set; get; }
        public int PageSize { set; get; }
        public List<DepartmentViewModel>? Departments { get; set; }
        public List<Position>? Positions { get; set; }
        public List<Literacy>? Literacies { get; set; }
        public string? FindKeyword { get; set; }

    }
}
