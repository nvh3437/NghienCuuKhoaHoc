using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.General.Enum;
using NghienCuuKhoaHoc.Models;
using X.PagedList;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public interface ICouncilMemberService
    {
        Task<IPagedList<CouncilMemberViewModel>> GetMembers(int page = 1, int pageSize = 1, string? Field = null, ResearchStatus? Status = null, int? Year = null, string? FindKeyword = null);
        Task<bool> UpdateRange(CouncilMemberViewModel member);
        Task<bool> UpdateAsync(CouncilMemberViewModel member);
        Task<bool> DeleteRange(CouncilMemberViewModel members);
    }
}
