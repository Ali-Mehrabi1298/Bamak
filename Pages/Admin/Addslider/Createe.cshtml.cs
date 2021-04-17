using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bamak.Models;
using BookAudiomak.Data;

namespace Bamak.Pages.Admin.Addslider.NewFolder
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
        ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id");
        ViewData["SlidNew_producId"] = new SelectList(_context.slidNew_Producs, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public PRODUCTTOSLIDER PRODUCTTOSLIDER { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PRODUCTTOSLIDERs.Add(PRODUCTTOSLIDER);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
