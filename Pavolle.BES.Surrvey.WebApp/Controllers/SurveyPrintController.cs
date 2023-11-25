using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.Surrvey.Common.Utils;

namespace Pavolle.BES.Surrvey.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(SurveyServerConsts.PrintSurveyConsts.BaseRoute)]
    public class SurveyPrintController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
