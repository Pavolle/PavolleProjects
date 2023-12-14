using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.GeoServer.Service.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
