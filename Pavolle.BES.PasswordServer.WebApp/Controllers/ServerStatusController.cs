using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.PasswordServer.WebApp.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
