using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.GeoServer.Service.Controllers
{
    public class DistrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
