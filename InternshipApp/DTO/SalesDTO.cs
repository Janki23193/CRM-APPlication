using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.DTO
{
    public class SalesDTO
    {
        public int SalesId { get; set; }
        public DateTime DateSold { get; set; }
        public int? CustomerId { get; set; }
        public String CustomerName { get; set; }
        public int? ProductId { get; set; }
        public String ProductName { get; set; }
        public int? StoreId { get; set; }
        public String StoreName { get; set; }
    }
}
