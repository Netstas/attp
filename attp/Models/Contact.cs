using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace attp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
