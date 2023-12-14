using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.GeoServer.Service.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
