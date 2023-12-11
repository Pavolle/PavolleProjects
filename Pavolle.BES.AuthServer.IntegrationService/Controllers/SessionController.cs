using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.AuthServer.Common.Utils;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    [Produces("application/json")]
    [Route(BesAuthServerApiUrlConsts.SesionUrlConsts.BaseRoute)]
    public class SessionController : Controller
    {
        //session id bilgisine göre kontrol sağlayacak ve tokenın geçerli olup olmadığını kontrol edecek
    }
}
