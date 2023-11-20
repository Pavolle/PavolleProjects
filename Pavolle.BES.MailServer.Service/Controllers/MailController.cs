using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.MailServer.Service.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
