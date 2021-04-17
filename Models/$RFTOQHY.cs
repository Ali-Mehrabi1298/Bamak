using BookAudiomak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAudiomak.Models
{
    public class CategoreAuthorName
    {


        public int Id { get; set; }

        public string Name  { get; set; }
        public string Description { get; set; }

        public ICollection<CategoryToProduct> categoryToProducts { get; set; }

    }
}
