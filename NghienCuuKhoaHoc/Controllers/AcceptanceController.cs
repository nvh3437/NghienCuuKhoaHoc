using Microsoft.AspNetCore.Mvc;
using NghienCuuKhoaHoc.Data;
using NghienCuuKhoaHoc.Data.Repositories;
using NghienCuuKhoaHoc.Models;
using NghienCuuKhoaHoc.Services;

namespace NghienCuuKhoaHoc.Controllers
{
    public class AcceptanceController : BaseController
    {
        private readonly IAcceptanceService AcceptanceService;
        private readonly IResearchService ResearchService;
        private readonly Context Context;
        public AcceptanceController(IResearchService researchService, IAcceptanceService acceptanceService, Context context)
        {
            this.AcceptanceService = acceptanceService;
            this.ResearchService = researchService;
            Context = context;
        }
        public async Task<IActionResult> Index(AcceptanceViewModel? model = null)
        {
            if (model == null)
            {
                model = new AcceptanceViewModel();
            }
            if(model.Page <= 0)
            {
                model.Page = 1;
            }
            if(model.PageSize <= 0)
            {
                model.PageSize = 10;
            }

            model.Fields = Context.Fields.ToList();
            ViewData["FindKeyword"] = model.FindKeyword;
            model.Acceptances = await AcceptanceService.GetAcceptances(model.Page, model.PageSize, model.Field, model.Acceptance, model.Rate, model.Year, model.FindKeyword);
            model.Years = await ResearchService.Years();
            ModelState.Clear();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AcceptanceViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Cập nhật thất bại");
            if (ModelState.IsValid)
            {
                var res = await AcceptanceService.UpdateAsync(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Cập nhật thành công");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(AcceptanceViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Xóa thất bại");
            var res = await AcceptanceService.DeleteRange(model);
            if (res)
            {
                notification.Change(NotificationType.Success, "Xóa thành công");
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
    }
}
