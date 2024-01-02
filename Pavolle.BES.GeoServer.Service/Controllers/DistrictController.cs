using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.GeoServer.Common.Utils;

namespace Pavolle.BES.GeoServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(GeoServerUrlConsts.DistrictUrlConsts.BaseRoute)]
    public class DistrictController : Controller
    {
    }
}
