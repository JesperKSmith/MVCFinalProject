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
    public class ImagesController : Controller
    {
        private IImageRepository repo;

        public ImagesController(IImageRepository repo)
        {
            this.repo = repo;
        }

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

        /*[HttpPost]
        public ActionResult Create(Image image)
        {
            if (ModelState.IsValid)
            {
                repo.InsertOrUpdate(image);
                return RedirectToAction("Index");
            }
            return View();
        }*/

        [HttpPost]
        public ActionResult Create(Image image)
        {
            if (ModelState.IsValid)
            {
                //db
                int id = repo.InsertOrUpdate(image);
                //file
                var count = Request.Files.Count;
                if (count > 0)
                {
                    var files = Request.Files[0];
                    if (files.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(files.FileName);
                        var fileName = "" + id + extension;
                        var fileLocation = Path.Combine(Server.MapPath("~/Pictures"), fileName);
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
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}