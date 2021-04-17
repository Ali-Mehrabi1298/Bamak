using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookAudiomak.Data;
using BookAudiomak.Models;

namespace Bamak.Pages.Admin.category
{
    public class IndexModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public IndexModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.categories.ToListAsync();
        }
    }
}
