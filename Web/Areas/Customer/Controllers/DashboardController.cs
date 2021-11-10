using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Customer.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
