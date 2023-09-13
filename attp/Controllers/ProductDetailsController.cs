using Microsoft.AspNetCore.Mvc;

namespace attp.Controllers
{
    public class ProductDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
