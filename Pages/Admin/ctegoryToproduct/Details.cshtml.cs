using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookAudiomak.Data;
using BookAudiomak.Models;

namespace Bamak.Pages.Admin.ctegoryToproduct
{
    public class DetailsModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public DetailsModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        public CategoryToProduct CategoryToProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryToProduct = await _context.categoryToProducts
                .Include(c => c.category)
                .Include(c => c.product).FirstOrDefaultAsync(m => m.ProductId == id);

            if (CategoryToProduct == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
