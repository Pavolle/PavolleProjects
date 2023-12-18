using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.DYS.WebApp.Controllers
{
    public class FolderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
