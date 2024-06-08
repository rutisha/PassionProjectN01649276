using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProjectN01649276.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }
    }

    public class CustomerDto
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }
    }
}