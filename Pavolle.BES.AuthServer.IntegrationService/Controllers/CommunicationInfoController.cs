using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    public class CommunicationInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
