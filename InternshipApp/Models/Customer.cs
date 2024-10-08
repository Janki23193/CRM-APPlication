﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Please enter the Name")]
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Sales> sales { get; set; }
    }
}
