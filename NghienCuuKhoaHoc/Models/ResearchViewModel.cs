using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.General.Enum;
using NghienCuuKhoaHoc.General.Extension;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace NghienCuuKhoaHoc.Models
{
    public class ResearchViewModel
    {
        [Required(ErrorMessage = "là bắt buộc")]
        [RegularExpression("[A-Za-z0-9]*", ErrorMessage = "là chữ và số")]
        [StringLength(12, ErrorMessage = "phải trong phạm vi {2} - {1} Ký tự.", MinimumLength = 4)]
        public string Id { get; set; }

        [Required(ErrorMessage = "là bắt buộc")]
        [StringLength(512, ErrorMessage = "phải nhỏ hơn {1} Ký tự.")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "là bắt buộc")]
        public string? InstructorId { get; set; }
        public string? Instructor { get; set; }

        [Required(ErrorMessage = "là bắt buộc")]
        [StringLength(128, ErrorMessage = "phải nhỏ hơn {1} Ký tự.")]
        public string? Field { get; set; }
        public Decimal? Expense { get; set; }

        [Required(ErrorMessage = "là bắt buộc")]
        public string? DateStarted { get; set; }

        [Required(ErrorMessage = "là bắt buộc")]
        public string? DateExpired { get; set; }

        [Required(ErrorMessage = "là bắt buộc")]
        public General.Enum.ResearchStatus? Status { get; set; }

        public List<Field>? Fields { get; set; }
        public IPagedList<ResearchViewModel>? Researches { get; set; }
        public int Page { set; get; }
        public int PageSize { set; get; }
        public List<Personal>? Personals { get; set; }
        public List<ResearchFile>? ResearchFiles { get; set; }
        public List<IFormFile>? NewResearchFiles { get; set; }
        public List<string>? DeleteFiles { get; set; }
        public int? Year { set; get; }
        public List<int>? Years { set; get; }
        public string? FindKeyword { get; set; }
    }
}
