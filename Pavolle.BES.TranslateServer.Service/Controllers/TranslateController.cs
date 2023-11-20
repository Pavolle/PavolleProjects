using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.TranslateServer.Service.Controllers
{
    public class TranslateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
