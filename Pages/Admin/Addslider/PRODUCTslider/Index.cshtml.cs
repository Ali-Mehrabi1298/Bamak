using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bamak.Models;
using BookAudiomak.Data;

namespace Bamak.Pages.Admin.Addslider.NewFolder
{
    public class IndexModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public IndexModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        public IList<PRODUCTTOSLIDER> PRODUCTTOSLIDER { get;set; }

        public async Task OnGetAsync()
        {
            PRODUCTTOSLIDER = await _context.PRODUCTTOSLIDERs
                .Include(p => p.product)
                .Include(p => p.slidNew_Produc).ToListAsync();
        }
    }
}
