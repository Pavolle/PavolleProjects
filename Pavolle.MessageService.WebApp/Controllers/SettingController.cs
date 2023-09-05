using Microsoft.AspNetCore.Mvc;

namespace Pavolle.MessageService.WebApp.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
