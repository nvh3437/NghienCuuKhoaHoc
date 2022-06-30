using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.General.Enum;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace NghienCuuKhoaHoc.Models
{
    public class CouncilMemberViewModel
    {
        [Required(ErrorMessage = "là bắt buộc")]
        [RegularExpression("[A-Za-z0-9]*",ErrorMessage ="là chữ và số")]
        [StringLength(128, ErrorMessage = "phải trong phạm vi {2} - {1} Ký tự.", MinimumLength = 4)]
        public string ResearchId { get; set; }        
        public List<CouncilMember>? Members { get; set; }        
        public string? Chairman { get; set; }
        public string? Commissioner1 { get; set; }
        public string? Commissioner2 { get; set; }
        public string? Secretary { get; set; }

        public string? Subject { get; set; }
        public string? Instructor { get; set; }
        public string? DateStarted { get; set; }
        public string? DateExpired { get; set; }
        public General.Enum.ResearchStatus? Status { get; set; }
        public string? Field { get; set; }

        public List<Personal>? Personals { get; set; }
        public List<Field>? Fields { get; set; }
        public string GetCouncilStatus()
        {
            string str;
            if(Members.Count != null && Members.Count < 4)
            {
                if(Members.Count > 0)
                {
                    str = "Hội đồng chưa đủ thành viên";
                }
                else
                {
                    str = "Chưa có hội dồng";
                }
            }
            else
            {
                str = "Đã đủ thành viên hội đồng";
            }
            return str;
        }
        public string GetClass()
        {
            string htmlclass;
            if(Members.Count != null && Members.Count < 4)
            {
                if(Members.Count > 0)
                {
                    htmlclass = "text-warning";
                }
                else
                {
                    htmlclass = "text-danger";
                }
            }
            else
            {
                htmlclass = "text-success";
            }
            return htmlclass;
        }
        public IPagedList<CouncilMemberViewModel>? CouncilMembers { get; set; }
        public List<string>? selectedResearches { get; set; }
        public string? FindKeyword { get; set; }
        public int Page { set; get; }
        public List<int>? Years { set; get; }
        public int? Year { set; get; }
        public int PageSize { set; get; }
    }
}
