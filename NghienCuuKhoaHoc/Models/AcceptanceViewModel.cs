using NghienCuuKhoaHoc.Data.Models;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace NghienCuuKhoaHoc.Models
{
    public class AcceptanceViewModel
    {
        [Required(ErrorMessage = "là bắt buộc")]
        [RegularExpression("[A-Za-z0-9]*", ErrorMessage = "là chữ và số")]
        [StringLength(128, ErrorMessage = "phải trong phạm vi {2} - {1} Ký tự.", MinimumLength = 4)]
        public string ResearchId { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "phải trong phạm vi {2} - {1}")]
        public double? Score { get; set; }
        public string? Subject { get; set; }
        public string? Instructor { get; set; }
        public string? DateStarted { get; set; }    
        public string? DateExpired { get; set; }
        public General.Enum.AcceptanceStatus? Acceptance { get; set; }
        public General.Enum.AcceptanceRate? Rate { get; set; }
        public string? Field { get; set; }
        public List<Field>? Fields { get; set; }
        public IPagedList<AcceptanceViewModel>? Acceptances { get; set; }
        public int Page { set; get; }
        public int PageSize { set; get; }
        public List<int>? Years { set; get; }
        public int? Year { set; get; }
        public List<string>? selectedResearches { get; set; }
        public string? FindKeyword { get; set; }
    }
}
