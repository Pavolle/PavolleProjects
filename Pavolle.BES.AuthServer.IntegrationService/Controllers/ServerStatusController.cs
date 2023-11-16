using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
