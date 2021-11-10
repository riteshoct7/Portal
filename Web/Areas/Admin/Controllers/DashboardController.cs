using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
