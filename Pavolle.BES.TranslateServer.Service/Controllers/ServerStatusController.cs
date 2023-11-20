using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.TranslateServer.Service.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
