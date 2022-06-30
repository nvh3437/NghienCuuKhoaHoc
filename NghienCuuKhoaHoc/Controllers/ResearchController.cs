using Microsoft.AspNetCore.Mvc;
using NghienCuuKhoaHoc.Data;
using NghienCuuKhoaHoc.Data.Repositories;
using NghienCuuKhoaHoc.Models;
using NghienCuuKhoaHoc.Services;

namespace NghienCuuKhoaHoc.Controllers
{
    public class ResearchController : BaseController
    {
        private readonly IResearchService ResearchService;
        private readonly Context Context;
        public ResearchController(IResearchService ResearchService, Context context)
        {
            this.ResearchService = ResearchService;
            this.Context = context;
        }
        public async Task<IActionResult> Index(ResearchViewModel? model = null)
        {
            if (model == null)
            {
                model = new ResearchViewModel();
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
            model.Fields = Context.Fields.ToList();
            model.Personals = Context.Personals.ToList();
            model.Researches = await ResearchService.GetResearches(model.Page, model.PageSize, model.Field, model.Status, model.Year, model.FindKeyword);
            model.Years = await ResearchService.Years();
            ModelState.Clear();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ResearchViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Thêm thất bại");
            if (ModelState.IsValid)
            {
                var res = await ResearchService.AddAsync(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Thêm thành công");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(ResearchViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Cập nhật thất bại");
            if (ModelState.IsValid)
            {
                var res = await ResearchService.UpdateAsync(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Cập nhật thành công");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(List<string> selectedResearches)
        {
            Notification notification = new Notification(NotificationType.Danger, "Xóa thất bại");
            var res = await ResearchService.DeleteRange(selectedResearches);
            if (res)
            {
                notification.Change(NotificationType.Success, "Xóa thành công");
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Extend(List<string> selectedResearches, int years = 0, int months = 0, int days = 0)
        {
            Notification notification = new Notification(NotificationType.Danger, "Gia hạn thất bại");
            var res = await ResearchService.ExtendRange(selectedResearches, years, months, days);
            if (res)
            {
                notification.Change(NotificationType.Success, "Gia hạn thành công");
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(ResearchDetailViewModel model)
        {
            model = await ResearchService.ResearchDetail(model.Id); 
            return View(model);
        }
    }
}
