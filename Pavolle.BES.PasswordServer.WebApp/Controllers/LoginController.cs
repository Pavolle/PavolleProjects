using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.PasswordServer.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
