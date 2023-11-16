using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    public class UserGroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
