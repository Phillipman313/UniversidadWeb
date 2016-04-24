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
    public class MatriculasController : Controller
    {
        private UniversidadBDEntities db = new UniversidadBDEntities();

        // GET: Matriculas
        public ActionResult Index()
        {
            var matricula = db.Matricula.Include(m => m.Estudiante).Include(m => m.Periodo);
            return View(matricula.ToList());
        }

        // GET: Matriculas/Details/5
        // Hola
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matricula.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Estudiante = new SelectList(db.Estudiante, "Id_Estudiante", "Cod_Estudiante");
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "Id_Periodo");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Matricula,CodMatricula,Id_Periodo,Id_Estudiante,Estado,Monto")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matricula.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Estudiante = new SelectList(db.Estudiante, "Id_Estudiante", "Cod_Estudiante", matricula.Id_Estudiante);
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "Id_Periodo", matricula.Id_Periodo);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matricula.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Estudiante = new SelectList(db.Estudiante, "Id_Estudiante", "Cod_Estudiante", matricula.Id_Estudiante);
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "Id_Periodo", matricula.Id_Periodo);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Matricula,CodMatricula,Id_Periodo,Id_Estudiante,Estado,Monto")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Estudiante = new SelectList(db.Estudiante, "Id_Estudiante", "Cod_Estudiante", matricula.Id_Estudiante);
            ViewBag.Id_Periodo = new SelectList(db.Periodo, "Id_Periodo", "Id_Periodo", matricula.Id_Periodo);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matricula.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = db.Matricula.Find(id);
            db.Matricula.Remove(matricula);
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
