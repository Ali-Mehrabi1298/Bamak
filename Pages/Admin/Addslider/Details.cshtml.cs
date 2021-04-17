using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookAudiomak.Data;
using BookAudiomak.Models;

namespace Bamak.Pages.Admin.Addslider
{
    public class DetailsModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public DetailsModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        public SlidNew_produc SlidNew_produc { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SlidNew_produc = await _context.slidNew_Producs.FirstOrDefaultAsync(m => m.Id == id);

            if (SlidNew_produc == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
