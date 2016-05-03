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
    public class CursoLectivosController : Controller
    {
        private UniversidadBDEntities db = new UniversidadBDEntities();

        // GET: CursoLectivos
        public ActionResult Index()
        {
            var cursoLectivo = db.CursoLectivo.Include(c => c.Curso).Include(c => c.Periodo).Include(c => c.Profesor);
            return View(cursoLectivo.ToList());
        }

        // GET: CursoLectivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoLectivo cursoLectivo = db.CursoLectivo.Find(id);
            if (cursoLectivo == null)
            {
                return HttpNotFound();
            }
            return View(cursoLectivo);
        }

        // GET: CursoLectivos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Curso = new SelectList(db.Curso, "Id_Curso", "Cod_Curso");
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "Id_Periodo");
            ViewBag.Id_Profesor = new SelectList(db.Profesor, "Id_Profesor", "CodProfesor");
            return View();
        }

        // POST: CursoLectivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_CursoLectivo,CursoLectivo1,Maximo,Id_Profesor,Id_Curso,Id_Periodo")] CursoLectivo cursoLectivo)
        {
            if (ModelState.IsValid)
            {
                cursoLectivo.Sobrante = cursoLectivo.Maximo;
                db.CursoLectivo.Add(cursoLectivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Curso = new SelectList(db.Curso, "Id_Curso", "Cod_Curso", cursoLectivo.Id_Curso);
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "Id_Periodo", cursoLectivo.Id_Periodo);
            ViewBag.Id_Profesor = new SelectList(db.Profesor, "Id_Profesor", "CodProfesor", cursoLectivo.Id_Profesor);
            return View(cursoLectivo);
        }

        // GET: CursoLectivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoLectivo cursoLectivo = db.CursoLectivo.Find(id);
            if (cursoLectivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Curso = new SelectList(db.Curso, "Id_Curso", "Cod_Curso", cursoLectivo.Id_Curso);
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "Id_Periodo", cursoLectivo.Id_Periodo);
            ViewBag.Id_Profesor = new SelectList(db.Profesor, "Id_Profesor", "CodProfesor", cursoLectivo.Id_Profesor);
            return View(cursoLectivo);
        }

        // POST: CursoLectivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_CursoLectivo,CursoLectivo1,Maximo,Id_Profesor,Id_Curso,Id_Periodo")] CursoLectivo cursoLectivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursoLectivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = cursoLectivo.Id_CursoLectivo });
            }
            ViewBag.Id_Curso = new SelectList(db.Curso, "Id_Curso", "Cod_Curso", cursoLectivo.Id_Curso);
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "Id_Periodo", cursoLectivo.Id_Periodo);
            ViewBag.Id_Profesor = new SelectList(db.Profesor, "Id_Profesor", "CodProfesor", cursoLectivo.Id_Profesor);
            return View(cursoLectivo);
        }

        // GET: CursoLectivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoLectivo cursoLectivo = db.CursoLectivo.Find(id);
            if (cursoLectivo == null)
            {
                return HttpNotFound();
            }
            return View(cursoLectivo);
        }

        // POST: CursoLectivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CursoLectivo cursoLectivo = db.CursoLectivo.Find(id);
            db.CursoLectivo.Remove(cursoLectivo);
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
