using Microsoft.AspNetCore.Mvc;

namespace Pavolle.MessageService.WebApp.Controllers
{
    public class UserGroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
