using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.Models;
using X.PagedList;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetDepartments(string? FindKeyword = null);
        Task<bool> AddAsync(DepartmentViewModel department);
        Task<bool> UpdateAsync(DepartmentViewModel department);
        Task<bool> DeleteRange(List<string> departments);
    }
}
