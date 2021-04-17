using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookAudiomak.Data;
using BookAudiomak.Models;

namespace Bamak.Pages.Admin.ctegoryToproduct
{
    public class CreateModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public CreateModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["categoryId"] = new SelectList(_context.categories, "Id", "Id");
        ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CategoryToProduct CategoryToProduct { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.categoryToProducts.Add(CategoryToProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
