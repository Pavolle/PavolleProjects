using Microsoft.AspNetCore.Mvc;

namespace Pavolle.MobileService.WebService.Controllers
{
    public class NumberMemoryController : Controller
    {
        //Veri listesi görüntüle
        //Veriyi güncelle
        public IActionResult Index()
        {
            return View();
        }
    }
}
