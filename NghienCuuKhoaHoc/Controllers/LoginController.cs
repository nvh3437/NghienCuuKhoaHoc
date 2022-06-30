using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NghienCuuKhoaHoc.Models;
using NghienCuuKhoaHoc.Services;

namespace NghienCuuKhoaHoc.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        public LoginController(SignInManager<IdentityUser> _signInManager, UserManager<IdentityUser> _userManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index","Login");
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            ModelState.Clear();
            var res = await signInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);
            if (!res.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Tài khoản hoặc mật khẩu không chính xác");
                return View(model);
            }
            if (res.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Tài khoản bị khóa thử lại sau");
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Change(LoginViewModel model)
        {
            ModelState.Clear();
            Notification notification = new Notification(NotificationType.Success, "Cập nhật thành công");
            var thisUser = await userManager.GetUserAsync(User);
            if(thisUser == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var resul = await signInManager.CheckPasswordSignInAsync(thisUser,model.Password,false);
            if (!resul.Succeeded)
            {
                notification.Change(NotificationType.Danger, "Mật khẩu không chính xác"); 
                TempData["Notification"] = notification.ToJson();
                return RedirectToAction("Index", "Home");
            }
            if(thisUser.UserName != model.UserName)
            {
               var res = await userManager.SetUserNameAsync(thisUser, model.UserName);
                if (!res.Succeeded)
                {
                    notification.Change(NotificationType.Danger, "Có lỗi xảy ra, chưa thay đổi UserName");
                    TempData["Notification"] = notification.ToJson();
                    return RedirectToAction("Index", "Home");
                }
            }
            if(thisUser.Email != model.Email)
            {
               var res = await userManager.SetEmailAsync(thisUser, model.Email);
                if (!res.Succeeded)
                {
                    notification.Change(NotificationType.Danger, "Có lỗi xảy ra, chưa thay đổi Email");
                    TempData["Notification"] = notification.ToJson();
                    return RedirectToAction("Index", "Home");
                }
            }
            if (model.NewPassword != null)
            {
                var res = await userManager.ChangePasswordAsync(thisUser, model.Password, model.NewPassword);
                if (!res.Succeeded)
                {
                    notification.Change(NotificationType.Danger, "Có lỗi xảy ra, chưa thay đổi Password");
                    TempData["Notification"] = notification.ToJson();
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index", "Home");
        }
    }
}
