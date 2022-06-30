using System.ComponentModel.DataAnnotations;

namespace NghienCuuKhoaHoc.Models
{
    public class AccountViewModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "là bắt buộc ")]
        [RegularExpression(@"[0-9a-zA-z^\S]*", ErrorMessage = "chỉ chấp nhận chữ và số ")]
        [StringLength(350, ErrorMessage = "phải trong phạm vi {2} - {1} ký tự ", MinimumLength = 4)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "là bắt buộc ")]
        [EmailAddress(ErrorMessage = "Định dạng phải là email ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "là bắt buộc ")]
        [StringLength(100, ErrorMessage = "phải trong phạm vi {2} - {1} ký tự ", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [StringLength(100, ErrorMessage = "phải trong phạm vi {2} - {1} ký tự ", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string? RePassword { get; set; }
        public string? FindKeyword { get; set; }
        public bool? Admin { get; set; }
        public List<string>? selectedAccounts { get; set; }
        public List<AccountViewModel>? Accounts { get; set; }
    }
}
