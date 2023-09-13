using attp.Models;
using Microsoft.AspNetCore.Mvc;

namespace attp.Controllers
{
    public class CartController : Controller
    {
        private readonly AttpContext attpContext;

        public CartController(AttpContext db)
        {
            attpContext = db;
        }

        public IActionResult Index()
        {
            var dbPc = attpContext.Carts.ToList();
            return View(dbPc);
        }
    }
}
