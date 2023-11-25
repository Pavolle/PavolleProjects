using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.Surrvey.IntegrationService.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
