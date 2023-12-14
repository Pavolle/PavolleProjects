using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.GeoServer.Service.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
