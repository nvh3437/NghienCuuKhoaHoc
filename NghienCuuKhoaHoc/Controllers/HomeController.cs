using Microsoft.AspNetCore.Mvc;
using NghienCuuKhoaHoc.Data.Repositories;
using NghienCuuKhoaHoc.Models;
using System.Diagnostics;

namespace NghienCuuKhoaHoc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAcceptanceService AcceptanceService;
        private readonly IResearchService ResearchService;
        private readonly IPersonalService PersonalService;

        public HomeController(ILogger<HomeController> logger, 
            IAcceptanceService acceptanceService, 
            IResearchService researchService, 
            IPersonalService personalService)
        {
            _logger = logger;
            AcceptanceService = acceptanceService;
            ResearchService = researchService;
            PersonalService = personalService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.TotalAcceptedResearch = await AcceptanceService.TotalAcceptedResearch();
            model.TotalResearch = await ResearchService.TotalResearch();
            model.TotalPersonal = await PersonalService.TotalPersonal();
            model.RecentResearches = await ResearchService.RecentResearches();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}