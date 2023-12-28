using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BorderSecurity.IntegrationEndpoint.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
