using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalExamProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Some more information about Worlds Ugliest Lamps";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Worlds Ugliest Lamps";

            return View();
        }
    }
}