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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Bamak.Pages.Admin.AddFileee
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
        public Filess Filess { get; set; }
        [BindProperty]
        public IFormFile uploudeFile { get; set; }
        [BindProperty]
        public AddProducts Add { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(/*[FromServices] IWebHostEnvironment env*/)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }





            _context.Filess.Add(Filess);
            await _context.SaveChangesAsync();




            if (Add.Pictore?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "File",
                Filess.Name+Path.GetExtension(Add.Pictore.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Add.Pictore.CopyTo(stream);
                }
            }

          




            return RedirectToPage("./Index");
        }
    }
}
