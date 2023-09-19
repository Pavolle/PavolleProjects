using DevExpress.Utils.Filtering.Internal;
using Microsoft.AspNetCore.Mvc;
using Pavolle.Supplera.Common.Utils;

namespace Pavolle.Supplera.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(SuppleraApiUrlConsts.UyelikBasvuruIslemRouteConsts.Route)]
    public class UyelikBasvuruIslemController : Controller
    {
        //Buraya sadece yetkili kullanıcılar erişebilecek.
        //Yetkili kullanıcıların üyelik başvurularını değerlendireceği altyapının kurulması

        // Üyelik başvurularını görüntüle
        // Üyelik başvurusu ile ilgili not ekle
        // Üyelik başvurusu ile ilgili cevap yaz
        // Yeni uyelik oluştur.
        public IActionResult Index()
        {
            return View();
        }
    }
}
