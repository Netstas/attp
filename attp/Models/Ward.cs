using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace attp.Models
{
    public class Ward
    {
        public int Id { get; set; }
        public string WardName { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }

    }
}
