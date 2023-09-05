using Microsoft.AspNetCore.Mvc;

namespace Pavolle.MessageService.WebApp.Controllers
{
    public class DefinitionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
