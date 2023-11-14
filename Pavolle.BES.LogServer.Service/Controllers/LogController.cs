using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.LogServer.Service.Controllers
{
    public class LogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
