using FinalExamProject.Models;
using FinalExamProject.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalExamProject.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        private string storagePath = "~/Pictures";
        private IImageRepository repo;

        public ImagesController(IImageRepository repo)
        {
            this.repo = repo;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index(string search = "")
        {
            return View(repo.GetAll(search));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repo.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                repo.InsertOrUpdate(image);
                return RedirectToAction("Index");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(repo.Find(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Image image)
        {
            if (ModelState.IsValid)
            {
                
                //file
                var count = Request.Files.Count;
                if (count > 0)
                {
                    var files = Request.Files[0];
                    if (files.ContentLength > 0)
                    {
                        //db
                        int id = repo.InsertOrUpdate(image);
                        string extension = Path.GetExtension(files.FileName);
                        var fileName = "" + id + extension;
                        var fileLocation = Path.Combine(Server.MapPath(storagePath), fileName);
                        files.SaveAs(fileLocation);
                        //update extension
                        image.ImageExtension = extension;
                        repo.InsertOrUpdate(image);

                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Image temp = repo.Find(id);
            string fileName = temp.ImageId + temp.ImageExtension;
            string imageFilePath = Path.Combine(Server.MapPath(storagePath), fileName);
            if (System.IO.File.Exists(imageFilePath))
            {
                System.IO.File.Delete(imageFilePath);
            }
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}