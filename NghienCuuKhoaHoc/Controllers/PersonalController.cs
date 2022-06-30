using Microsoft.AspNetCore.Mvc;
using NghienCuuKhoaHoc.Data;
using NghienCuuKhoaHoc.Data.Repositories;
using NghienCuuKhoaHoc.Models;
using NghienCuuKhoaHoc.Services;

namespace NghienCuuKhoaHoc.Controllers
{
    public class PersonalController : BaseController
    {
        private readonly IPersonalService PersonalService;
        private readonly IDepartmentService DepartmentService;
        private readonly Context Context;
        public PersonalController(IPersonalService personalService, IDepartmentService departmentService, Context context)
        {
            this.PersonalService = personalService;
            DepartmentService = departmentService;
            Context = context;
        }
        public async Task<IActionResult> Index(PersonalViewModel? model = null)
        {
            if (model == null)
            {
                model = new PersonalViewModel();
            }
            if (model.Page <= 0)
            {
                model.Page = 1;
            }
            if (model.PageSize <= 0)
            {
                model.PageSize = 10;
            }
            ViewData["FindKeyword"] = model.FindKeyword;
            model.Personals = await PersonalService.GetPersonals(model.Page, model.PageSize, model.Department, model.FindKeyword);
            model.Departments = await DepartmentService.GetDepartments();
            model.Literacies = Context.Literacies.ToList();
            model.Positions = Context.Positions.ToList();
            ModelState.Clear();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PersonalViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Thêm thất bại");
            if (ModelState.IsValid)
            {
                var res = await PersonalService.AddAsync(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Thêm thành công");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(PersonalViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Cập nhật thất bại");
            if (ModelState.IsValid)
            {
                var res = await PersonalService.UpdateAsync(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Cập nhật thành công");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(List<string> selectedPersonals)
        {
            Notification notification = new Notification(NotificationType.Danger, "Xóa thất bại");
            var res = await PersonalService.DeleteRange(selectedPersonals);
            if (res)
            {
                notification.Change(NotificationType.Success, "Xóa thành công");
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(PersonalDetailViewModel model)
        {
            model = await PersonalService.PersonalDetail(model.Id);
            return View(model);
        }
    }
}
