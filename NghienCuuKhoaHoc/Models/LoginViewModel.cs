using System.ComponentModel.DataAnnotations;

namespace NghienCuuKhoaHoc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "là bắt buộc")]
        [StringLength(64, ErrorMessage = "phải trong phạm vi {2} - {1} Ký tự.", MinimumLength = 4)]
        public string UserName { get; set;}

        [Required(ErrorMessage = "là bắt buộc")]
        [StringLength(64, ErrorMessage = "phải trong phạm vi {2} - {1} Ký tự.", MinimumLength = 4)]
        public string Password { get; set;}
        [Required(ErrorMessage = "là bắt buộc ")]
        [EmailAddress(ErrorMessage = "Định dạng phải là email ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "là bắt buộc ")]
        [StringLength(100, ErrorMessage = "phải trong phạm vi {2} - {1} ký tự ", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }
    }
}
