using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AppServer.WebApp.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
