using Microsoft.AspNetCore.Mvc;
using NghienCuuKhoaHoc.Data;
using NghienCuuKhoaHoc.Data.Repositories;
using NghienCuuKhoaHoc.Models;

namespace NghienCuuKhoaHoc.Controllers
{
    public class PrintController : Controller
    {
        private readonly IResearchService ResearchService;
        private readonly IPersonalService PersonalService;
        private readonly Context Context;
        public PrintController(IPersonalService PersonalService,IResearchService ResearchService, Context context)
        {
            this.ResearchService = ResearchService;
            this.PersonalService = PersonalService;
            this.Context = context;
        }
        public async Task<IActionResult> ResearchAsync(ResearchDetailViewModel model)
        {
            model = await ResearchService.ResearchDetail(model.Id);
            return View(model);
        }
        public async Task<IActionResult> PersonalAsync(PersonalDetailViewModel model)
        {
            model = await PersonalService.PersonalDetail(model.Id);
            return View(model);
        }
    }
}
