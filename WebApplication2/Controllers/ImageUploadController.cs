using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.NewFolder;
using Microsoft.AspNetCore.Hosting;
using WebApplication2.Models.view;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class ImageUploadController : Controller
    {
        private readonly ApplicationContext context;
        private readonly IWebHostEnvironment environment;

        public ImageUploadController(ApplicationContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadImage(ImageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var path = environment.WebRootPath;
                var filePath = "Content/Image/" + model.ImagePath.FileName;
                var FullPath = Path.Combine(path, filePath);
                UploadFile(model.ImagePath, FullPath);
                var data = new Image()
                {
                    Name = model.Name,
                    ImagePath = filePath
                };
                context.Images.Add(data);
                context.SaveChanges();
                return RedirectToAction("getImages");

            }
            else
            {
                return View(model);
            }
        }
        private void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }

        public IActionResult getImages()
        {
            var result = context.Images.ToList();
            TempData["message"] = "Employee Loaded";
            return View(result);
        }

    }
}
