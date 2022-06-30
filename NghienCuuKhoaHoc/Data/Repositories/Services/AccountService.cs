using Microsoft.AspNetCore.Identity;
using NghienCuuKhoaHoc.Data.Repositories;
using NghienCuuKhoaHoc.Models;

namespace NghienCuuKhoaHoc.Data.Repositories
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly Context Context;
        public AccountService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, Context context)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            Context = context;
        }

        public async Task<bool> CreateAsync(AccountViewModel account)
        {
            try
            {
                var findUser = await UserManager.FindByNameAsync(account.UserName);
                if (findUser != null)
                {
                    return false;
                }
                IdentityUser user = Activator.CreateInstance<IdentityUser>();
                await UserManager.SetEmailAsync(user, account.Email);
                await UserManager.SetUserNameAsync(user, account.UserName);
                var res = await UserManager.CreateAsync(user, account.Password);
                if(account.Admin is true)
                {
                    await UserManager.AddToRoleAsync(user, "Admin");
                }
                return res.Succeeded;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteRange(AccountViewModel account)
        {
            try
            {
                var userRole = await UserManager.GetUsersInRoleAsync("Admin");
                foreach (string id in account.selectedAccounts)
                {
                    var findUser = await UserManager.FindByIdAsync(id);
                    if(findUser != null)
                    {
                        if(userRole != null && userRole.Count <= 1 && findUser.Id == userRole.FirstOrDefault().Id)
                        {
                            return false;
                        }
                        await UserManager.DeleteAsync(findUser);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<AccountViewModel>> GetAccounts(string? FindKeyword = null)
        {
            var userRole = Context.UserRoles.Select(e => e.UserId).ToList();

            var res = UserManager.Users.Select(e=>new AccountViewModel()
            {
                Id = e.Id,
                Email = e.Email,
                UserName = e.UserName,
                Admin = userRole.Contains(e.Id)?true:false,
            }).ToList();
            if(FindKeyword != null)
            {
                res = res.Where(x => x.Email == FindKeyword || x.UserName == FindKeyword).ToList();
            }
            return res;
        }

        public async Task<bool> UpdateAsync(AccountViewModel account)
        {
            try
            {
                var findUser = await UserManager.FindByIdAsync(account.Id);
                if (findUser != null)
                {
                    var userRole = await UserManager.GetUsersInRoleAsync("Admin");
                    if (userRole != null && userRole.Count <= 1 && findUser.Id == userRole.FirstOrDefault().Id)
                    {
                        return false;
                    }

                    await UserManager.SetEmailAsync(findUser, account.Email);
                    await UserManager.SetUserNameAsync(findUser, account.UserName);
                    if(account.RePassword != null)
                    {
                        var hasher = new PasswordHasher<IdentityUser>();
                        findUser.PasswordHash = hasher.HashPassword(findUser, account.RePassword);
                    }
                    var res = await UserManager.UpdateAsync(findUser);
                    return res.Succeeded;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
