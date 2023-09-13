using Microsoft.AspNetCore.Mvc;

namespace attp.Controllers
{
    public class IntroduceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
