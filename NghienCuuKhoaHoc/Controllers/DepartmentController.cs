using Microsoft.AspNetCore.Mvc;
using NghienCuuKhoaHoc.Data.Repositories;
using NghienCuuKhoaHoc.Models;
using NghienCuuKhoaHoc.Services;

namespace NghienCuuKhoaHoc.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService _departmentService)
        {
            departmentService = _departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new DepartmentViewModel();
            ViewData["FindKeyword"] = model.FindKeyword;
            model.Departments = await departmentService.GetDepartments(model.FindKeyword);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Thêm thất bại");
            if (ModelState.IsValid)
            {
                var res = await departmentService.AddAsync(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Thêm thành công");
                }
                else
                {
                    notification.Change(NotificationType.Warning, "Mã Khoa đã tồn tại");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Cập nhật thất bại");
            if (ModelState.IsValid)
            {
                var res = await departmentService.UpdateAsync(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Cập nhật thành công");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(List<string> selectedDepartments)
        {


            Notification notification = new Notification(NotificationType.Danger, "Xóa thất bại");
            var res = await departmentService.DeleteRange(selectedDepartments);
            if (res)
            {
                notification.Change(NotificationType.Success, "Xóa thành công");
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
    }
}
