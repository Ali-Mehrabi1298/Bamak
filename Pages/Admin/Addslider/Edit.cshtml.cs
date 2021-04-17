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
using Bamak.Models;
using System.IO;

namespace Bamak.Pages.Admin.Addslider
{
    public class EditModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public EditModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        [BindProperty]
        public SlidNew_produc SlidNew_produc { get; set; }
        [BindProperty]
        public AddEditProductViewModel Productse { get; set; }
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SlidNew_produc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlidNew_producExists(SlidNew_produc.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            if (Productse.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Image",
                SlidNew_produc.NewBookName + Path.GetExtension(Productse.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Productse.Picture.CopyTo(stream);
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SlidNew_producExists(int id)
        {
            return _context.slidNew_Producs.Any(e => e.Id == id);
        }
    }
}
