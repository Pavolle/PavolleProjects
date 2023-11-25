using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.Surrvey.IntegrationService.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
