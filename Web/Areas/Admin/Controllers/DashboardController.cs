using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        #region Fields
        private readonly INotyfService notyf; 
        #endregion

        #region Constuctors

        public DashboardController(INotyfService notyf)
        {
            this.notyf = notyf;
        }
        #endregion

        #region Methods
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
        #endregion
    }
}
