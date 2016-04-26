using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversidadWeb.Models;

namespace UniversidadWeb.Controllers
{
    public class HomeController : Controller
    {
        private UniversidadBDEntities db = new UniversidadBDEntities();
        public ActionResult Index()
        {
            var cursosLectivos = db.CursoLectivo.ToList();
            return View(cursosLectivos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}