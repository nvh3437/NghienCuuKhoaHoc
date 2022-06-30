using Microsoft.AspNetCore.Mvc;
using NghienCuuKhoaHoc.Data;
using NghienCuuKhoaHoc.Data.Repositories;
using NghienCuuKhoaHoc.Models;
using NghienCuuKhoaHoc.Services;

namespace NghienCuuKhoaHoc.Controllers
{
    public class CouncilController : BaseController
    {
        private readonly ICouncilMemberService CouncilMemberService; 
        private readonly IResearchService ResearchService;
        private readonly Context Context;
        public CouncilController(IResearchService researchService, ICouncilMemberService councilMemberService, Context context)
        {
            this.CouncilMemberService = councilMemberService;
            this.ResearchService = researchService;
            Context = context;
        }
        public async Task<IActionResult> Index(CouncilMemberViewModel? model = null)
        {
            if (model == null)
            {
                model = new CouncilMemberViewModel();
            }
            if (model.Page <= 0)
            {
                model.Page = 1;
            }
            if (model.PageSize <= 0)
            {
                model.PageSize = 10;
            }
            model.Fields = Context.Fields.ToList();
            model.Personals = Context.Personals.ToList(); 
            ViewData["FindKeyword"] = model.FindKeyword;
            model.CouncilMembers = await CouncilMemberService.GetMembers(model.Page, model.PageSize, model.Field, model.Status, model.Year, model.FindKeyword);
            model.Years = await ResearchService.Years();
            ModelState.Clear();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRange(CouncilMemberViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Cập nhật thất bại");
            ModelState.Remove("ResearchId");
            if (ModelState.IsValid)
            {
                var res = await CouncilMemberService.UpdateRange(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Cập nhật thành công");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(CouncilMemberViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Cập nhật thất bại");
            if (ModelState.IsValid)
            {
                var res = await CouncilMemberService.UpdateAsync(model);
                if (res)
                {
                    notification.Change(NotificationType.Success, "Cập nhật thành công");
                }
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CouncilMemberViewModel model)
        {
            Notification notification = new Notification(NotificationType.Danger, "Xóa thất bại");
            var res = await CouncilMemberService.DeleteRange(model);
            if (res)
            {
                notification.Change(NotificationType.Success, "Xóa thành công");
            }
            TempData["Notification"] = notification.ToJson();
            return RedirectToAction("Index");
        }
    }
}
