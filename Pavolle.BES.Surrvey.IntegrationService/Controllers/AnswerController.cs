using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.Surrvey.Common.Utils;

namespace Pavolle.BES.Surrvey.IntegrationService.Controllers
{
    [Produces("application/json")]
    [Route(SurveyServerConsts.SurveyIntegrationServiceConsts.AnswerRoute)]
    public class AnswerController : Controller
    {
    }
}
