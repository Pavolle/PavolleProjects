using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.TranslateServer.Service.Controllers
{
    public class TranslateDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
