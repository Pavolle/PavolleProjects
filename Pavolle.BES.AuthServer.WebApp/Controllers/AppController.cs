using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.AuthServer.Common.Utils;

namespace Pavolle.BES.AuthServer.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(BesAuthServerApiUrlConsts.AppServiceConsts.Route)]
    public class AppController : Controller
    {
        //list, //add //edit
    }
}
