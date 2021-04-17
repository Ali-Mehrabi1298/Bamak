using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookAudiomak.Data;
using BookAudiomak.Models;

namespace Bamak.Pages.Admin.ctegoryToproduct
{
    public class EditModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public EditModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["categoryId"] = new SelectList(_context.categories, "Id", "Id");
           ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id");
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

            _context.Attach(CategoryToProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryToProductExists(CategoryToProduct.ProductId))
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

        private bool CategoryToProductExists(int id)
        {
            return _context.categoryToProducts.Any(e => e.ProductId == id);
        }
    }
}
