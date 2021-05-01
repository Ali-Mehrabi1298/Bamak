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


      

    [HttpPost("FileUpload")]
            public async Task<IActionResult> Index(List<IFormFile> files)
            {
                long size = files.Sum(f => f.Length);

                var filePaths = new List<string>();
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                    // full path to file in temp location
                    var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
                    filePaths.Add(filePath);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }


        //    if (Add.Pictore?.Length > 0)
        //    {
        //        string filePath = Path.Combine(Directory.GetCurrentDirectory(),
        //            "wwwroot",
        //            "File",
        //        Path.GetExtension(Add.Pictore.FileName));
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            Add.Pictore.CopyTo(stream);
        //        }
        //    }
        //    return RedirectToAction("Ali");
        //}

        //public IActionResult Ali()
        //{
        //    return View();


        //}



                // process uploaded files
                // Don't rely on or trust the FileName property without validation.

                return Ok(new { count = files.Count, size, filePaths });
            }
        }




    }

