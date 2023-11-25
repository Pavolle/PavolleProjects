using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.DYS.EndPointIntegrationService.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
