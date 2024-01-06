using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AppServer.MobileAppIntegration.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
