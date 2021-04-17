using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bamak.Models
{
    public class AddEditProductViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ItemId { get; set; }
        public bool PDf { get; set; }
        public string AthourName { get; set; }
        public int QuantityInStock { get; set; }
        public bool Free { get; set; }
        public IFormFile Picture { get; set; }


    }
}
