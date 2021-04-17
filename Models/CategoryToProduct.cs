using Bamak.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAudiomak.Models
{
    public class CategoryToProduct
    {
        
        public int Id { get; set; }
        public int ProductId { get; set; }

        //public string  ProductName { get; set; }

        /*    public string  categoryName { get; set; */
    
          public int categoryId { get; set; }
          public int AuthorId { get; set; }

    //public string AuthorName { get; set; }

    public Product product { get; set; }



    public Category category { get; set; }


    public CategoreAuthorName CategoreAuthorName { get; set; }


}
}
