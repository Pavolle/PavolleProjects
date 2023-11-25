using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.Surrvey.IntegrationService.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
