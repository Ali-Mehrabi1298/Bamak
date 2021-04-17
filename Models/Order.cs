using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAudiomak.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public DateTime dateTime { get; set; }

    
        public bool IsFinaly { get; set; }

      
       
        //[ForeignKey("UserId")]
       

        public List<OrderDetail> OrderDetails { get; set; }



    }
}
