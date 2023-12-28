using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.PasswordServer.WebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
