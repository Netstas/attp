using Microsoft.AspNetCore.Mvc;

namespace attp.Controllers
{
    public class AdministrativeunitsController : Controller
    {
        public IActionResult Cities()
        {
            return View();
        }
        public IActionResult Districts()
        {
            return View();
        }
        public IActionResult Wards()
        {
            return View();
        }
    }
}
