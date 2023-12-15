using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.Supplera.WebApp.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
