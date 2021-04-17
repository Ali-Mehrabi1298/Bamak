using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bamak.Models;
using BookAudiomak.Data;

namespace Bamak.Pages.Admin.Addslider.NewFolder
{
    public class DeleteModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public DeleteModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        [BindProperty]
        public PRODUCTTOSLIDER PRODUCTTOSLIDER { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PRODUCTTOSLIDER = await _context.PRODUCTTOSLIDERs
                .Include(p => p.product)
                .Include(p => p.slidNew_Produc).FirstOrDefaultAsync(m => m.ProductId == id);

            if (PRODUCTTOSLIDER == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PRODUCTTOSLIDER = await _context.PRODUCTTOSLIDERs.FindAsync(id);

            if (PRODUCTTOSLIDER != null)
            {
                _context.PRODUCTTOSLIDERs.Remove(PRODUCTTOSLIDER);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
