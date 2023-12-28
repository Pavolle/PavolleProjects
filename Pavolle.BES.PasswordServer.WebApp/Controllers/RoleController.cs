using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.PasswordServer.WebApp.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
