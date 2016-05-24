using FinalExamProject.Models;
using FinalExamProject.Repositories;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public ActionResult Create(Image image)
        {
            if (ModelState.IsValid)
            {
                repo.InsertOrUpdate(image);
                return RedirectToAction("Index");
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