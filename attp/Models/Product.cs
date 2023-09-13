using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace attp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Ảnh sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa chọn ảnh")]
        public string image { get; set; }
        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        public int quantity { get; set; }
        [Display(Name = "Giảm giá")]
        [Required(ErrorMessage = "Bạn chưa nhập giảm giá")]
        public string discount { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public int productcode { get; set; }
        [Display(Name = "Mô tả sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập mô tả sản phẩm")]
        public string ProductDescription { get; set; }
        [Display(Name = "Danh mục sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa chọn danh mục sản phẩm")]
        public int ProductCategoryId { get; set; }
        public ProductCategory Category { get; set; }
        [Display(Name = "Giá tiền")]
        [Required(ErrorMessage = "Bạn chưa nhập giá tiền")]
        public decimal Price { get; set; }
        [Display(Name = "Giảm giá")]
        public decimal PriceSale { get; set; }
    }
}
