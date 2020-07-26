using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample.Contexts;
using DependencyInjectionExample.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    public class NewsController : Controller
    {
        private readonly IWebHostEnvironment webHost_;
        private readonly NewsContext context_;
        public NewsController(NewsContext context, IWebHostEnvironment webHost)
        {
            context_ = context;
            webHost_ = webHost;
        }
        public IActionResult Index()
        {
            var a = context_.News.ToList(); 

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id", "Title", "CreationDate", "FormFile")]News news)
        {
            if (ModelState.IsValid)
            {
                var newFileName = 
                    $"{Path.GetFileNameWithoutExtension(news.FormFile.FileName)}" +
                    $"-{DateTime.Now.ToString("MM/dd/yyyy")}" +
                    $"{Path.GetExtension(news.FormFile.FileName)}";

                var rootPath = Path.Combine(webHost_.WebRootPath, "images", newFileName);

                using (var fileStream = new FileStream(rootPath, FileMode.Create))
                {
                    news.FormFile.CopyTo(fileStream);
                }

                news.FileName = newFileName;
                context_.News.Add(news);
                context_.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}