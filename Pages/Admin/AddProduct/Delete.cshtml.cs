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

namespace Bamak.Pages.Admin.AddProduct
{
    public class DeleteModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public DeleteModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.products.FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
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


            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                               "wwwroot",
                               "Image",
                           Product.Name + ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }


            Product = await _context.products.FindAsync(id);

            if (Product != null)
            {
                _context.products.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
