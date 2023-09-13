using System;
using attp.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using X.PagedList;
using X.PagedList.Mvc;
using Microsoft.EntityFrameworkCore;

namespace attp.Controllers
{

    public class AdminController : Controller
    {
        private readonly AttpContext db;
        private readonly IWebHostEnvironment hostingEnvironment;
        public AdminController(AttpContext db, IWebHostEnvironment hostingEnvironment)
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;
        }
        // page
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Product(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var query = db.Products
                         .Join(
                             db.ProductCategories,
                             product => product.ProductCategoryId,
                             category => category.Id,
                             (product, category) => new
                             {
                                 Product = product,
                                 CategoryName = category.CategoryName
                             });


            ViewBag.Products = query.ToPagedList(pageNumber, pageSize);
            return View();
        }

        public IActionResult ProductCategories()
        {
            var data = db.ProductCategories.ToList();
            ViewBag.ProductCategories = data;

            return View();
        }
        public IActionResult ProductReviews()
        {
            return View();
        }
        public IActionResult Order()
        {
            return View();
        }

        // feature
        // Thêm sản phẩm mới
        public IActionResult CreateProduct()
        {
            var datapc = db.ProductCategories.ToList();
            ViewBag.ProductCategories = datapc;

            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product p, List<IFormFile> Image)
        {
            if (ModelState.IsValid != null)
            {
                if (!string.IsNullOrEmpty(p.discount))
                {
                    if (decimal.TryParse(p.discount, out decimal discountPercentage))
                    {
                        decimal originalPrice = p.Price;
                        decimal discountAmount = (discountPercentage / 100) * originalPrice;
                        p.PriceSale = originalPrice - discountAmount;
                    }
                    else
                    {
                        ModelState.AddModelError("discount", "Giảm giá phải là một số hợp lệ.");
                    }
                }

                var imagePaths = new List<string>();
                foreach (var image in Image)
                {
                    if (image.Length > 0)
                    {
                        var fileName = Path.GetFileName(image.FileName);
                        var filePath = Path.Combine(hostingEnvironment.WebRootPath, "Uploads", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }

                        imagePaths.Add(fileName);
                    }
                }

                p.image = string.Join(",", imagePaths);
                db.Products.Add(p);
                db.SaveChanges();

                return RedirectToAction(nameof(Product));
            }

            var datapc = db.ProductCategories.ToList();
            ViewBag.ProductCategories = datapc;

            return View();
        }

        public IActionResult UpdateProduct(int id)
        {
            var data = db.Products.FirstOrDefault(p => p.Id == id);
            var datapc = db.ProductCategories.ToList();
            ViewBag.ProductCategories = datapc;
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product, List<IFormFile> Image)
        {
            try
            {
                if (ModelState.IsValid != null)
                {
                    db.Products.Update(product);
                    db.SaveChanges();
                    var getProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);

                    if (!string.IsNullOrEmpty(getProduct.image) && Image != null && getProduct.image != product.image)
                    {
                        var deletedImageNames = getProduct.image?.Split(',') ?? Array.Empty<string>();
                        var uploadedImageNames = product.image?.Split(',') ?? Array.Empty<string>();

                        var imagesToDelete = deletedImageNames.Except(uploadedImageNames);

                        foreach (var imageName in imagesToDelete)
                        {
                            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", imageName);
                            if (System.IO.File.Exists(imagePath))
                            {
                                System.IO.File.Delete(imagePath);
                            }
                        }
                    }
                    if (Image != null && Image.Any())
                    {
                        var imagePaths = new List<string>();
                        foreach (var image in Image)
                        {
                            if (image.Length > 0)
                            {
                                var fileName = Path.GetFileName(image.FileName);
                                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", fileName);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    image.CopyTo(stream);
                                }

                                imagePaths.Add(fileName);
                            }
                        }

                        product.image = string.Join(",", imagePaths);
                    }
                    db.SaveChanges();
                    return RedirectToAction(nameof(Product));

                }

                var datapc = db.ProductCategories.ToList();
                ViewBag.ProductCategories = datapc; ;
                return View(product);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        //Danh mục sản phẩm
        public IActionResult CreateProductCategories()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProductCategories(ProductCategory pc)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(pc);
                db.SaveChanges();
                return RedirectToAction("ProductCategories");
            }
            return View();
        }
        //Cập nhập sản phẩm
        public IActionResult UpdateProductCategories(int id)
        {
            if (ModelState.IsValid)
            {
                var data = db.ProductCategories.FirstOrDefault(pc => pc.Id == id);
                return View(data);
            }
            return RedirectToAction("ProductCategories");

        }
        [HttpPost]
        public IActionResult UpdateProductCategories(ProductCategory pc)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Update(pc);
                db.SaveChanges();
                return RedirectToAction("ProductCategories");
            }
            return View();
        }
        [HttpPost]
        public IActionResult DeleteProductCategories(int id)
        {
            try
            {
                var categoryToDelete = db.ProductCategories.Find(id);

                if (categoryToDelete != null)
                {
                    db.ProductCategories.Remove(categoryToDelete);
                    db.SaveChanges();

                    return Json(new { success = true });
                }

                return Json(new { success = false, message = "Không tìm thấy danh mục sản phẩm để xoá." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
