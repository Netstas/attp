﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace attp.Models
{
    public class ArticleCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
