using Bamak.Models;
using BookAudiomak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAudiomak.Models
{
    public class SlidNew_produc
    {

        public int Id { get; set; }
        public string NewBookName { get; set; }
        public string Description { get; set; }
   
        public ICollection<PRODUCTTOSLIDER> PRODUCTTOSLIDERs { get; set; }
    }
}
