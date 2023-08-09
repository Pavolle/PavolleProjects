using Microsoft.AspNetCore.Mvc;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Supplera.Business.Genel;
using Pavolle.Supplera.Common.Utils;
using Pavolle.Supplera.ViewModels.Request;

namespace Pavolle.Supplera.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(SuppleraApiUrlConsts.UyelikBasvuruRouteConsts.Route)]
    public class UyelikBasvuruController : Controller
    {

        [HttpPost(SuppleraApiUrlConsts.UyelikBasvuruRouteConsts.UyelikBasvuruDetayRoutePrefix)]
        public ActionResult Detail(string referansNumarasi, [FromBody] RequestBase request)
        {
            return Ok(UyelikBasvuruManager.Instance.Detail(referansNumarasi, request));
        }

        [HttpPost(SuppleraApiUrlConsts.AddRoutePrefix)]
        public ActionResult Add([FromBody] UyelikBasvuruRequest request)
        {
            return Ok(UyelikBasvuruManager.Instance.Add(request));
        }

        [HttpPost(SuppleraApiUrlConsts.UyelikBasvuruRouteConsts.AddMessageRoutePrefix)]
        public ActionResult Add([FromBody] UyelikBasvuruMesajRequest request)
        {
            return Ok(UyelikBasvuruManager.Instance.UyelikBasvuruMesaj(request));
        }
    }
}
