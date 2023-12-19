using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.DYS.Common.Utils;

namespace Pavolle.BES.DYS.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(DYSConsts.DocumentAccessConsts.BaseRoute)]
    public class DocumentAccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
