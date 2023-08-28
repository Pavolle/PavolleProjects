using Microsoft.AspNetCore.Mvc;

namespace Pavolle.MessageService.WebApp.Controllers
{
    public class TranslateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
