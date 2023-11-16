using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.DYS.WebApp.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
