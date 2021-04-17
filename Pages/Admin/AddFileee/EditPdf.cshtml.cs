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
using System.IO;

namespace Bamak.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public EditModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        [BindProperty]
        public PdfModel PdfModel { get; set; }
        [BindProperty]
        public AddEditProductViewModel Productse { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PdfModel = await _context.PdfModels.FirstOrDefaultAsync(m => m.Id == id);

            if (PdfModel == null)
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

            _context.Attach(PdfModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdfModelExists(PdfModel.Id))
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
                "Pdf",
                PdfModel.ProductName + Path.GetExtension(Productse.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Productse.Picture.CopyTo(stream);
                }

            }


            return RedirectToPage("./Index");
        }

        private bool PdfModelExists(int id)
        {
            return _context.PdfModels.Any(e => e.Id == id);
        }
    }
}
