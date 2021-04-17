using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bamak.Models
{
    public class AddProducts
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        public string AthuorName { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }
        public bool IsFire { get; set; }
        public int MyProperty { get; set; }
        public string AutherName { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public IFormFile Pictore { get; set; }
    }
}
