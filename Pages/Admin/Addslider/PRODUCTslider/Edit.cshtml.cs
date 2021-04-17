using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bamak.Models;
using BookAudiomak.Data;

namespace Bamak.Pages.Admin.Addslider.NewFolder
{
    public class EditModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public EditModel(BookAudiomak.Data.Bookmakcontex context)
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
           ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id");
           ViewData["SlidNew_producId"] = new SelectList(_context.slidNew_Producs, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PRODUCTTOSLIDER).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTTOSLIDERExists(PRODUCTTOSLIDER.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PRODUCTTOSLIDERExists(int id)
        {
            return _context.PRODUCTTOSLIDERs.Any(e => e.ProductId == id);
        }
    }
}
