using FinalExamProject.Models;
using FinalExamProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalExamProject.Controllers
{
    public class LampsController : Controller
    {
        private ILampRepository lampRepo;
        private IImageRepository imageRepo;

        public LampsController(ILampRepository lampRepo, IImageRepository imageRepo)
        {
            this.lampRepo = lampRepo;
            this.imageRepo = imageRepo;
        }

        [HttpGet]
        public ActionResult Index(string search = "")
        {
            return View(lampRepo.GetAll(search));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(lampRepo.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Lamp lamp)
        {
            if(ModelState.IsValid)
            {
                lampRepo.InsertOrUpdate(lamp);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(lampRepo.Find(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.possibleImages = imageRepo.GetAll("");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Lamp lamp)
        {
            if(ModelState.IsValid)
            {
                lampRepo.InsertOrUpdate(lamp);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            lampRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}