using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BorderSecurity.IntegrationService.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
