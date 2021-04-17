using Bamak.Models;
using BookAudiomak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAudiomak.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        public string AutherName { get; set; }
        public bool Pdf { get; set; }

        public int Price { get; set; }

        public bool Free { get; set; }
        public ICollection<CategoryToProduct> categoryToProducts { get; set; }

        //public Item item { get; set; }
        public ICollection<Filess> Filesses { get; set; }

        

    }
}
