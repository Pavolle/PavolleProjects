using Microsoft.AspNetCore.Mvc;

namespace Pavolle.Supplera.WebApp.Controllers
{
    public class AppController : Controller
    {
        //Burada amaç örneğin kendi sunucusu için uygulama almış bir kullanıcının üyelik başvurusu gibi bir modül ile karşılaşmasını önlemek

        //IsAlive metodu ile sunucunun ayakta olup olmadığını kontrol etmek
        public IActionResult Index()
        {
            return View();
        }
    }
}
