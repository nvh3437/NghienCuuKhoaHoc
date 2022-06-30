using NghienCuuKhoaHoc.Models;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public interface IAccountService
    {
        Task<List<AccountViewModel>> GetAccounts(string? FindKeyword = null);
        Task<bool> CreateAsync(AccountViewModel account);
        Task<bool> UpdateAsync(AccountViewModel account);
        Task<bool> DeleteRange(AccountViewModel account);
    }
}
