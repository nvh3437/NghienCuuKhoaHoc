using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.General.Enum;
using NghienCuuKhoaHoc.Models;
using X.PagedList;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public interface IResearchService
    {
        Task<IPagedList<ResearchViewModel>> GetResearches(int page = 1, int pageSize = 1, string? Field = null, ResearchStatus? Status = null, int? Year = null, string? FindKeyword = null);
        Task<bool> AddAsync(ResearchViewModel re);
        Task<bool> UpdateAsync(ResearchViewModel re);
        Task<bool> DeleteRange(List<string> rees);
        Task<bool> ExtendRange(List<string> rees,int years = 0, int months = 0, int days = 0);
        Task<int> TotalResearch();
        Task<List<ResearchViewModel>> RecentResearches();
        Task<List<int>> Years();
        Task<ResearchDetailViewModel> ResearchDetail(string id);
    }
}
