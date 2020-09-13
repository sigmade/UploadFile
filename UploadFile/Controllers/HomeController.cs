using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UploadFile.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace UploadFile.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _context;
        IWebHostEnvironment _appEnvironment;

        public HomeController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View(_context.Files.ToList());
        }
        [HttpPost]
        //public async Task<IActionResult> AddFile(string altitude, IFormFile uploadedFile)
        //{
        //    if (uploadedFile != null)
        //    {
        //        string name = altitude;
        //       // путь к папке Files
        //       string path = "/Files/" + uploadedFile.FileName;
        //        // сохраняем файл в папку Files в каталоге wwwroot
        //        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
        //        {
        //            await uploadedFile.CopyToAsync(fileStream);
        //        }
        //        FileModel file = new FileModel { Name = name, Path = path };
        //        _context.Files.Add(file);
        //        _context.SaveChanges();
        //    }

        //    return RedirectToAction("Index");
        //}

        public async Task<IActionResult> AddFile(string personid, IFormFile passFile, IFormFile pass2File)
        {
            string name = personid;

            if (passFile != null)
            {
               // путь к папке Files
                string path = "/Files/" + passFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await passFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = name, Path = path };
                _context.Files.Add(file);
                _context.SaveChanges();
            }

            if (pass2File != null)
            {
                // путь к папке Files
                string path = "/Files/" + pass2File.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await passFile.CopyToAsync(fileStream);
                }
                FileModel file2 = new FileModel { Name = name, Path = path };
                _context.Files.Add(file2);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}