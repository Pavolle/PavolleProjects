using Microsoft.AspNetCore.Mvc;

namespace Pavolle.MobileService.WebService.Controllers
{
    public class MessageServiceController : Controller
    {
        //Kullanıcıların mesaj gönderebileceği ve mesajlarına cevap alabileceği bir altyapı inşa edeceğiz.
        public IActionResult Index()
        {
            return View();
        }
    }
}
