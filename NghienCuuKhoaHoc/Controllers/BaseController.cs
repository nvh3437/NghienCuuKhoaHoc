using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NghienCuuKhoaHoc.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
