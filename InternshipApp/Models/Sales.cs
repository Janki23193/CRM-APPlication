using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.Models
{
    public class Sales
    {
        [Key]
        public int SalesId { get; set; }
        public DateTime DateSold { get; set; }       
        public int? CustomerId { get; set; }
        public Customer customer { get; set; }
        public int? ProductId { get; set; }
        public Product product { get; set; }
        public int? StoreId { get; set; }
        public Store store { get; set; }


    }
}
