using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.MailServer.Service.Controllers
{
    public class ServerStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
