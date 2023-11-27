using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    public class LoginController : Controller
    {
        //login, logout, token check service
        public IActionResult Index()
        {
            return View();
        }
    }
}
