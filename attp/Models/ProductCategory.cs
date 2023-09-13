using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace attp.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        [Display(Name ="Danh mục sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục sản phẩm.")]
        public string CategoryName { get; set; }
    }
}
