using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.GeoServer.Common.Utils;

namespace Pavolle.BES.GeoServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(GeoServerUrlConsts.AddressUrlConsts.BaseRoute)]
    public class AddressController : Controller
    {
    }
}
