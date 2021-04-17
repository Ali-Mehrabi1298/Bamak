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

namespace Bamak.Pages.Admin.AddFileee
{
    public class DeleteModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public DeleteModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        [BindProperty]
        public Filess Filess { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filess = await _context.Filess.FirstOrDefaultAsync(m => m.Id == id);

            if (Filess == null)
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

            Filess = await _context.Filess.FindAsync(id);

            if (Filess != null)
            {
                _context.Filess.Remove(Filess);
                await _context.SaveChangesAsync();
            }




            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
               "wwwroot",
               "File",
             Filess.Name+".mp4");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }




            return RedirectToPage("./Index");
        }
    }
}
