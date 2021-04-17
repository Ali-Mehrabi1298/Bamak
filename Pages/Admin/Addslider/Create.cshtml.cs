using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookAudiomak.Data;
using BookAudiomak.Models;
using Bamak.Models;
using System.IO;

namespace Bamak.Pages.Admin.Addslider
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
        public SlidNew_produc SlidNew_produc { get; set; }
        [BindProperty]
        public AddEditProductViewModel Productse { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.slidNew_Producs.Add(SlidNew_produc);
            await _context.SaveChangesAsync();


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
    }
}
