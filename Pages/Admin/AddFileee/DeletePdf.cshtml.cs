using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bamak.Models;
using BookAudiomak.Data;
using System.IO;

namespace Bamak.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public DeleteModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        [BindProperty]
        public PdfModel PdfModel { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PdfModel = await _context.PdfModels.FindAsync(id);

            if (PdfModel != null)
            {
                _context.PdfModels.Remove(PdfModel);
                await _context.SaveChangesAsync();
            }
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
              "wwwroot",
              "File",
            PdfModel.ProductName + ".pdf");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToPage("./Index");
        }
    }
}
