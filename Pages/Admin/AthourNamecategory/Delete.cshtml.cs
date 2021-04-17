using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookAudiomak.Data;
using BookAudiomak.Models;

namespace Bamak.Pages.Admin.AddCategory.AthourNamecategory
{
    public class DeleteModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public DeleteModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoreAuthorName CategoreAuthorName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoreAuthorName = await _context.AuthorNames.FirstOrDefaultAsync(m => m.Id == id);

            if (CategoreAuthorName == null)
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

            CategoreAuthorName = await _context.AuthorNames.FindAsync(id);

            if (CategoreAuthorName != null)
            {
                _context.AuthorNames.Remove(CategoreAuthorName);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
