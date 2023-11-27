using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
