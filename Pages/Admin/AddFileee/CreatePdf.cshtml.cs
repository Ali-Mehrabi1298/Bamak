using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bamak.Models;
using BookAudiomak.Data;
using System.IO;
using BookAudiomak.Models;

namespace Bamak.Pages.Admin
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
            return Page();
        }

        [BindProperty]
        public PdfModel PdfModel { get; set; }
        [BindProperty]
        public AddEditProductViewModel Productse { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PdfModels.Add(PdfModel);
            await _context.SaveChangesAsync();
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
    }
}
