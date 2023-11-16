using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
