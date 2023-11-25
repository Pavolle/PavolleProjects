using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.Surrvey.IntegrationService.Controllers
{
    public class QuestionGroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
