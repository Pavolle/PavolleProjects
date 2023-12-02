using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.JobServer.IntegrationService.Controllers
{
    public class JobController : Controller
    {
        //listele, detay, (düzenle, ekle bu kısım aynı zamanda job listesesini de güncelleyecek) //runlog
        public IActionResult Index()
        {
            return View();
        }
    }
}
