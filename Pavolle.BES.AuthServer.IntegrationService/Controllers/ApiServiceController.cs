using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    public class ApiServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
