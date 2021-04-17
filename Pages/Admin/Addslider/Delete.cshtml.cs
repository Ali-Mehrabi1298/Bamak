using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookAudiomak.Data;
using BookAudiomak.Models;
using System.IO;

namespace Bamak.Pages.Admin.Addslider
{
    public class DeleteModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public DeleteModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        [BindProperty]
        public SlidNew_produc SlidNew_produc { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SlidNew_produc = await _context.slidNew_Producs.FindAsync(id);

            if (SlidNew_produc != null)
            {
                _context.slidNew_Producs.Remove(SlidNew_produc);
                await _context.SaveChangesAsync();
            }


            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                             "wwwroot",
                             "Image",
                          SlidNew_produc.NewBookName + ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }




            return RedirectToPage("./Index");
        }
    }
}
