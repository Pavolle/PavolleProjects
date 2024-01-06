using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AppServer.WebSiteIntegration.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
