using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AppServer.CaptchaService.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
