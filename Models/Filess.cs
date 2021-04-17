using BookAudiomak.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bamak.Models
{
    public class Filess
    {


        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string  productName { get; set; }
     
        public int part { get; set; }

      


        //[ForeignKey("productName")]
        public Product product { get; set; }
        //public AddFilee AddFilee { get; set; }
    }
}
