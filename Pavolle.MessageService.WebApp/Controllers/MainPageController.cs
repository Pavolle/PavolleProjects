using Microsoft.AspNetCore.Mvc;

namespace Pavolle.MessageService.WebApp.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
