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
    public class MatriculaCursoesController : Controller
    {
        private UniversidadBDEntities db = new UniversidadBDEntities();

        // GET: MatriculaCursoes
        public ActionResult Index()
        {
            var matriculaCurso = db.MatriculaCurso.Include(m => m.Curso_Estudiante).Include(m => m.Matricula);
            return View(matriculaCurso.ToList());
        }

        // GET: MatriculaCursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatriculaCurso matriculaCurso = db.MatriculaCurso.Find(id);
            if (matriculaCurso == null)
            {
                return HttpNotFound();
            }
            return View(matriculaCurso);
        }

        // GET: MatriculaCursoes/Create
        public ActionResult Create()
        {
            ViewBag.Id_CursoLectivo = new SelectList(db.Curso_Estudiante, "Id_CursoEstudiante", "Estado");
            ViewBag.Id_Matricula = new SelectList(db.Matricula, "Id_Matricula", "CodMatricula");
            return View();
        }

        // POST: MatriculaCursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(MatriculaCurso matriculaCurso)
        {
            if (ModelState.IsValid)
            {
                db.MatriculaCurso.Add(matriculaCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_CursoLectivo = new SelectList(db.Curso_Estudiante, "Id_CursoEstudiante", "Estado", matriculaCurso.Id_CursoLectivo);
            ViewBag.Id_Matricula = new SelectList(db.Matricula, "Id_Matricula", "CodMatricula", matriculaCurso.Id_Matricula);
            return View(matriculaCurso);
        }

        // GET: MatriculaCursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatriculaCurso matriculaCurso = db.MatriculaCurso.Find(id);
            if (matriculaCurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_CursoLectivo = new SelectList(db.Curso_Estudiante, "Id_CursoEstudiante", "Estado", matriculaCurso.Id_CursoLectivo);
            ViewBag.Id_Matricula = new SelectList(db.Matricula, "Id_Matricula", "CodMatricula", matriculaCurso.Id_Matricula);
            return View(matriculaCurso);
        }

        // POST: MatriculaCursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_MatriculaCurso,Id_Matricula,Id_CursoLectivo")] MatriculaCurso matriculaCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matriculaCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_CursoLectivo = new SelectList(db.Curso_Estudiante, "Id_CursoEstudiante", "Estado", matriculaCurso.Id_CursoLectivo);
            ViewBag.Id_Matricula = new SelectList(db.Matricula, "Id_Matricula", "CodMatricula", matriculaCurso.Id_Matricula);
            return View(matriculaCurso);
        }

        // GET: MatriculaCursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatriculaCurso matriculaCurso = db.MatriculaCurso.Find(id);
            if (matriculaCurso == null)
            {
                return HttpNotFound();
            }
            return View(matriculaCurso);
        }

        // POST: MatriculaCursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatriculaCurso matriculaCurso = db.MatriculaCurso.Find(id);
            db.MatriculaCurso.Remove(matriculaCurso);
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
