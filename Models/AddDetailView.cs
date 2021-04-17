using Bamak.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAudiomak.Models
{
    public class AddDetailView
    {

        public Product product { get; set; }
      
        public  List<Category> categories { get; set; }

        public List<Filess> Filess { get; set; }

        

    }
}
