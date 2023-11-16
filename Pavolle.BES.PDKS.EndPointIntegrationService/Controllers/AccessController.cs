using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.PDKS.EndPointIntegrationService.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
