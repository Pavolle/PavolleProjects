using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AppServer.FormIntegration.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
