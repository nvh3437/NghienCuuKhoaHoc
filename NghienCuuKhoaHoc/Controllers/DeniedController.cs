using Microsoft.AspNetCore.Mvc;

namespace NghienCuuKhoaHoc.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
