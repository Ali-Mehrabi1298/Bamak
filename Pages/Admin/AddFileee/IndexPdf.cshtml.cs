using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bamak.Models;
using BookAudiomak.Data;

namespace Bamak.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly BookAudiomak.Data.Bookmakcontex _context;

        public IndexModel(BookAudiomak.Data.Bookmakcontex context)
        {
            _context = context;
        }

        public IList<PdfModel> PdfModel { get;set; }

        public async Task OnGetAsync()
        {
            PdfModel = await _context.PdfModels.ToListAsync();
        }
    }
}
