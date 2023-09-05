using Microsoft.AspNetCore.Mvc;

namespace Pavolle.MessageService.WebApp.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
