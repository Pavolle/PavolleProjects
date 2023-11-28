using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.AuthServer.Common.Utils;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    [Produces("application/json")]
    [Route(BesAuthServerApiUrlConsts.ApiServiceUrlConsts.BaseRoute)]
    public class ApiServiceController : Controller
    {
    }
}
