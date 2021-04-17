using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookAudiomak.Data;
using BookAudiomak.Models;

namespace Bamak.Pages.Admin.Addslider
{
    public class IndexModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public IndexModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        public IList<SlidNew_produc> SlidNew_produc { get;set; }

        public async Task OnGetAsync()
        {
            SlidNew_produc = await _context.slidNew_Producs.ToListAsync();
        }
    }
}
