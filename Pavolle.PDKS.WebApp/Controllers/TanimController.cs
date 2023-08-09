using Microsoft.AspNetCore.Mvc;

namespace Pavolle.PDKS.WebApp.Controllers
{
    public class TanimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
