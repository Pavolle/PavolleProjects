using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.PasswordServer.WebApp.Controllers
{
    public class PasswordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
