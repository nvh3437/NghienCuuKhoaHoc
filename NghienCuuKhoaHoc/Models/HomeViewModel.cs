using Microsoft.AspNetCore.Identity;

namespace NghienCuuKhoaHoc.Models
{
    public class HomeViewModel
    {
        public int? TotalResearch { get; set; }
        public int? TotalAcceptedResearch { get; set; }
        public int? TotalPersonal { get; set; }
        public List<ResearchViewModel> RecentResearches { get; set; }
    }
}
