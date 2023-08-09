using Microsoft.AspNetCore.Mvc;

namespace Pavolle.PDKS.CommServer.Controllers
{
    public class ServerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
