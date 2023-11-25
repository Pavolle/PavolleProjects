using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.Surrvey.Common.Utils;

namespace Pavolle.BES.Surrvey.IntegrationService.Controllers
{
    [Produces("application/json")]
    [Route(SurveyServerConsts.SurveyIntegrationServiceConsts.PrintSurveyRoute)]
    public class SurveyPrintController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
