using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.General.Enum;
using NghienCuuKhoaHoc.Models;
using X.PagedList;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public interface IAcceptanceService
    {
        Task<IPagedList<AcceptanceViewModel>> GetAcceptances(int page = 1, int pageSize = 1, string? Field = null, AcceptanceStatus? Status = null, AcceptanceRate? Rate = null, int? Year = null, string? FindKeyword = null);
        Task<bool> UpdateAsync(AcceptanceViewModel acceptance);
        Task<bool> DeleteRange(AcceptanceViewModel acceptance);
        Task<int> TotalAcceptedResearch();
    }
}
