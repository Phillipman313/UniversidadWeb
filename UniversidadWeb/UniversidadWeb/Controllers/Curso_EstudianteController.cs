using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversidadWeb.Models;

namespace UniversidadWeb.Controllers
{
    public class Curso_EstudianteController : Controller
    {
        private UniversidadBDEntities db = new UniversidadBDEntities();

        // GET: Curso_Estudiante
        public ActionResult Index()
        {
            var curso_Estudiante = db.Curso_Estudiante.Include(c => c.CursoLectivo).Include(c => c.Estudiante);
            return View(curso_Estudiante.ToList());
        }

        // GET: Curso_Estudiante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso_Estudiante curso_Estudiante = db.Curso_Estudiante.Find(id);
            if (curso_Estudiante == null)
            {
                return HttpNotFound();
            }
            return View(curso_Estudiante);
        }

        // GET: Curso_Estudiante/Create
        public ActionResult Create()
        {
            ViewBag.Id_CursoLectivo = new SelectList(db.CursoLectivo, "Id_CursoLectivo", "CursoLectivo1");
            ViewBag.Id_Estudiante = new SelectList(db.Estudiante, "Id_Estudiante", "Cod_Estudiante");
            return View();
        }

        // POST: Curso_Estudiante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_CursoEstudiante,Id_CursoLectivo,Id_Estudiante,Estado,Nota")] Curso_Estudiante curso_Estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Curso_Estudiante.Add(curso_Estudiante);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            ViewBag.Id_CursoLectivo = new SelectList(db.CursoLectivo, "Id_CursoLectivo", "CursoLectivo1", curso_Estudiante.Id_CursoLectivo);
            ViewBag.Id_Estudiante = new SelectList(db.Estudiante, "Id_Estudiante", "Cod_Estudiante", curso_Estudiante.Id_Estudiante);
            return View(curso_Estudiante);
        }

        // GET: Curso_Estudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso_Estudiante curso_Estudiante = db.Curso_Estudiante.Find(id);
            if (curso_Estudiante == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_CursoLectivo = new SelectList(db.CursoLectivo, "Id_CursoLectivo", "CursoLectivo1", curso_Estudiante.Id_CursoLectivo);
            ViewBag.Id_Estudiante = new SelectList(db.Estudiante, "Id_Estudiante", "Cod_Estudiante", curso_Estudiante.Id_Estudiante);
            return View(curso_Estudiante);


        }

        // POST: Curso_Estudiante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_CursoEstudiante,Id_CursoLectivo,Id_Estudiante,Estado,Nota")] Curso_Estudiante curso_Estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso_Estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_CursoLectivo = new SelectList(db.CursoLectivo, "Id_CursoLectivo", "CursoLectivo1", curso_Estudiante.Id_CursoLectivo);
            ViewBag.Id_Estudiante = new SelectList(db.Estudiante, "Id_Estudiante", "Cod_Estudiante", curso_Estudiante.Id_Estudiante);
            return View(curso_Estudiante);
        }

        // GET: Curso_Estudiante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso_Estudiante curso_Estudiante = db.Curso_Estudiante.Find(id);
            if (curso_Estudiante == null)
            {
                return HttpNotFound();
            }
            return View(curso_Estudiante);
        }

        // POST: Curso_Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso_Estudiante curso_Estudiante = db.Curso_Estudiante.Find(id);
            db.Curso_Estudiante.Remove(curso_Estudiante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
