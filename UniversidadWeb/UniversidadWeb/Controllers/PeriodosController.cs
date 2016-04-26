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
    public class PeriodosController : Controller
    {
        private UniversidadBDEntities db = new UniversidadBDEntities();

        // GET: Periodos
        public ActionResult Index()
        {
            var periodo = db.Periodo.Include(p => p.Anyo).Include(p => p.Ciclo).Include(p => p.Sede);
            return View(periodo.ToList());
        }

        // GET: Periodos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodo.Find(id);
            List<Curso> cursos = (from parte in periodo.CursoLectivo
                                  select parte.Curso).Distinct().ToList<Curso>();
            periodo.Cursos = cursos;
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        // GET: Periodos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Anyo = new SelectList(db.Anyo, "Id_Anyo", "Anyo1");
            ViewBag.Id_Ciclo = new SelectList(db.Ciclo, "Id_Ciclo", "Nombre");
            ViewBag.Id_Sede = new SelectList(db.Sede, "Id_Sede", "Nombre");
            return View();
        }

        // POST: Periodos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Periodo,Id_Ciclo,Id_Anyo,Id_Sede,Orden,FechaInicio,FechaFinal")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Periodo.Add(periodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Anyo = new SelectList(db.Anyo, "Id_Anyo", "Anyo1", periodo.Id_Anyo);
            ViewBag.Id_Ciclo = new SelectList(db.Ciclo, "Id_Ciclo", "Nombre", periodo.Id_Ciclo);
            ViewBag.Id_Sede = new SelectList(db.Sede, "Id_Sede", "Nombre", periodo.Id_Sede);
            return View(periodo);
        }

        // GET: Periodos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodo.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Anyo = new SelectList(db.Anyo, "Id_Anyo", "Anyo1", periodo.Id_Anyo);
            ViewBag.Id_Ciclo = new SelectList(db.Ciclo, "Id_Ciclo", "Nombre", periodo.Id_Ciclo);
            ViewBag.Id_Sede = new SelectList(db.Sede, "Id_Sede", "Nombre", periodo.Id_Sede);
            return View(periodo);
        }

        // POST: Periodos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Periodo,Id_Ciclo,Id_Anyo,Id_Sede,Orden,FechaInicio,FechaFinal")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Anyo = new SelectList(db.Anyo, "Id_Anyo", "Anyo1", periodo.Id_Anyo);
            ViewBag.Id_Ciclo = new SelectList(db.Ciclo, "Id_Ciclo", "Nombre", periodo.Id_Ciclo);
            ViewBag.Id_Sede = new SelectList(db.Sede, "Id_Sede", "Nombre", periodo.Id_Sede);
            return View(periodo);
        }

        // GET: Periodos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodo.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        // POST: Periodos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Periodo periodo = db.Periodo.Find(id);
            db.Periodo.Remove(periodo);
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
