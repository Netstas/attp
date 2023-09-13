using Microsoft.AspNetCore.Mvc;

namespace attp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
