using Bamak.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bamak.Controllers
{
    public class FileUploude : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [BindProperty]
        public IFormFile uploudeFile { get; set; }
        [BindProperty]
        public AddProducts Add { get; set; }
        [BindProperty]
        public Filess Filess { get; set; }


        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            if (Add.Pictore?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "File",
                Path.GetExtension(Add.Pictore.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Add.Pictore.CopyTo(stream);
                }
            }
            return RedirectToAction("Ali");
        }

        public IActionResult Ali()
        {
            return View();


            }

    }
}
         
                // process uploaded files
                // Don't rely on or trust the FileName property without validation.

    //        return Ok(new { count = files.Count, size, filePaths });
    //        }
    //    }




    //}

