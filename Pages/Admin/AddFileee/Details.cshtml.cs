using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bamak.Models;
using BookAudiomak.Data;

namespace Bamak.Pages.Admin.AddFileee
{
    public class DetailsModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public DetailsModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

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
    }
}
