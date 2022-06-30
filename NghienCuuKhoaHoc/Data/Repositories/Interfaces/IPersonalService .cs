using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.Models;
using X.PagedList;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public interface IPersonalService
    {
        Task<IPagedList<PersonalViewModel>> GetPersonals(int page = 1, int pageSize = 1, string? Department = null, string? FindKeyword = null);
        Task<bool> AddAsync(PersonalViewModel personal);
        Task<bool> UpdateAsync(PersonalViewModel personal);
        Task<bool> DeleteRange(List<string> personals);
        Task<int> TotalPersonal();
        Task<PersonalDetailViewModel> PersonalDetail(string id);

    }
}
