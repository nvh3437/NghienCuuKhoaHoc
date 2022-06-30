using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NghienCuuKhoaHoc.Data;
using NghienCuuKhoaHoc.Data.Repositories;
using NghienCuuKhoaHoc.Models;
using NghienCuuKhoaHoc.Services;

namespace NghienCuuKhoaHoc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : BaseController
    {
        private readonly IAccountService AccountService;
        private readonly Context Context;
        public AccountController(IAccountService accountService)
        {
            AccountService = accountService;
        }
        public async Task<IActionResult> Index(AccountViewModel? model = null)
        {
            if (model == null)
            {
                model = new AccountViewModel();
            }
            model.Accounts = await AccountService.GetAccounts(model.FindKeyword);
            ModelState.Clear();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Cập nhật thất bại");
            if (ModelState.IsValid)
            {
                var res = await AccountService.CreateAsync(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Cập nhật thành công");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(AccountViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Cập nhật thất bại");
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                var res = await AccountService.UpdateAsync(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Cập nhật thành công");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(AccountViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Xóa thất bại");
            var res = await AccountService.DeleteRange(model);
            if (res)
            {
                notification.Change(NotificationType.Success, "Xóa thành công");
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
    }
}
