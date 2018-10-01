using Assignment3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment3.Controllers
{
    public class CustomerBase
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

    }
}