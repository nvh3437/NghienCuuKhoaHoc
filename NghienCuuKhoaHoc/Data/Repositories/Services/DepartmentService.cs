using NghienCuuKhoaHoc.Data.Models;
using NghienCuuKhoaHoc.General.Extension;
using NghienCuuKhoaHoc.Models;
using X.PagedList;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public class DepartmentService : IDepartmentService
    {
        private readonly Context context;
        public DepartmentService(Context _context)
        {
            context = _context;
        }
        public async Task<bool> AddAsync(DepartmentViewModel department)
        {
            try
            {
                var departmentNew = new Department()
                {
                    Id = department.Id,
                    Name = department.Name,
                    CreatedDate = DateTime.Now
                };
                if (context.Departments.Where(d => d.Id == departmentNew.Id).ToList().Count() > 0)
                {
                    return false;
                }
                context.Add(departmentNew);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            catch {return false;}
        }

        public async Task<bool> DeleteRange(List<string> departments)
        {
            try
            {
                var _departments = new List<Department>();
                foreach (var department in departments)
                {
                    _departments.Add(new Department() { Id = department });
                }
                context.RemoveRange(_departments);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public async Task<List<DepartmentViewModel>> GetDepartments(string? FindKeyword = null)
        {
            var res = context.Departments
                .OrderBy(e => e.CreatedDate)
                .Select(e=>new DepartmentViewModel() { 
                    Id = e.Id, 
                    Name = e.Name, 
                    CreatedDate = e.CreatedDate.Value.ToString("dd/MM/yyyy")})
                .ToList();
            if (FindKeyword != null)
            {
                res = res.Where(e => e.Id.Contains(FindKeyword) 
                || e.Name.Contains(FindKeyword)).ToList();
            }
            return res;
        }

        public async Task<bool> UpdateAsync(DepartmentViewModel department)
        {
            try
            {
                var departmentNew = context.Departments.Where(e=>e.Id == department.Id).FirstOrDefault();
                departmentNew.Name = department.Name;
                context.Update(departmentNew);
                var res = await context.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

    }
}
