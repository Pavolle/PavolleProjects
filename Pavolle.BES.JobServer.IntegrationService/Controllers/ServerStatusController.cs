using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.JobServer.IntegrationService.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
