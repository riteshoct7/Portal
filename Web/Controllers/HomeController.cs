using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService notyf;

        public HomeController(ILogger<HomeController> logger, INotyfService notyf)
        {
            _logger = logger;
            this.notyf = notyf;
        }

        public IActionResult Index()
        {
            //notyf.Success("Success Notification");
            //notyf.Success("Success Notification that closes in 10 Seconds.", 3);
            //notyf.Error("Some Error Message");
            //notyf.Warning("Some Error Message");
            //notyf.Information("Information Notification - closes in 4 seconds.", 4);
            //notyf.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
            //notyf.Custom("Custom Notification - closes in 5 seconds.", 10, "#B600FF", "fa fa-home");
            return View();
        }

        [Authorize]
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