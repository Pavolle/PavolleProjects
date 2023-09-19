using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Common.Utils;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.DefinitionRouteConsts.Route)]
    public class DefinitionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
