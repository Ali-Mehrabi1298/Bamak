using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAudiomak.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAudiomak.Components
{
    public class Components : Controller
    {

        private Bookmakcontex _contex;
        public Components(Bookmakcontex contex)
        {

            _contex = contex;

        }


        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {
            ViewData["GroupName"] = name;
            var categores = _contex.categoryToProducts.Where(c => c.categoryId == id)
                .Include(d => d.product).Select(s => s.product).ToList();

            return View(categores);
        }

        //[Route("Groups/{id}/{nameee}")]
        //public IActionResult ShowAthurName(int id, string nameee)
        //{
        //    ViewData["GroupName"] = nameee;
        //    var AutherName = _contex.categoryToProducts.Where(c => c.AuthorId == id)
        //        .Include(d => d.product).Select(s => s.product).ToList();

        //    return View(AutherName);
        //}



        [Route("Groupss/{id}/{nameee}")]
        public IActionResult slidShow(int id, string nameee)
        {
            ViewData["GroupName"] = nameee;
            var Slid = _contex.PRODUCTTOSLIDERs.Where(c => c.SlidNew_producId == id)
                .Include(d => d.product).Select(s => s.product).ToList();

            return View(Slid);
        }



    }
}
