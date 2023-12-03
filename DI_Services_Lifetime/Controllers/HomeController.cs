using DI_Services_Lifetime.Models;
using DI_Services_Lifetime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace DI_Services_Lifetime.Controllers
{

    public class HomeController : Controller
    {
     
        public readonly ISingletonGuidService _singleton1;
        public readonly ISingletonGuidService _singleton2;

        public readonly ITransientGuidService _transient1;
        public readonly ITransientGuidService _transient2;

        public readonly IScopedGuidService _scoped1;
        public readonly IScopedGuidService _scoped2;

        public HomeController(ISingletonGuidService singleton1, ISingletonGuidService singleton2,
            ITransientGuidService transient1, ITransientGuidService transient2, IScopedGuidService scoped1, IScopedGuidService scoped2)
        {
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;

        }

   

        public IActionResult Index()
        {
            StringBuilder message = new StringBuilder();
            message.Append($"Transient 1 : {_transient1.GetGuid()} \n\n Transient 2 : {_transient2.GetGuid()} \n\n\n\n Scoped 1 : {_scoped1.GetGuid()} \n\n Scoped 2 : {_scoped2.GetGuid()} \n\n\n\n Singleton 1 : {_singleton1.GetGuid()} \n\n Singleton 2 : {_singleton2.GetGuid()}");
            return Ok(message.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
