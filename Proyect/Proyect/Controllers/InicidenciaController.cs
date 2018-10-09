using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyect.Context;
using Proyect.Models;

namespace Proyect.Controllers
{
    public class InicidenciaController : Controller
    {
        private ProyectContext db = new ProyectContext();

        // GET: Inicidencia
        public ActionResult Index()
        {
            var inicidencias = db.Inicidencias.Include(i => i.Tarea);
            return View(inicidencias.ToList());
        }

        // GET: Inicidencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inicidencia inicidencia = db.Inicidencias.Find(id);
            if (inicidencia == null)
            {
                return HttpNotFound();
            }
            return View(inicidencia);
        }

        // GET: Inicidencia/Create
        public ActionResult Create()
        {
            ViewBag.TareaID = new SelectList(db.Tareas, "TareaID", "asunto");
            return View();
        }

        // POST: Inicidencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncidenciaID,Descripcion,TareaID")] Inicidencia inicidencia)
        {
            if (ModelState.IsValid)
            {
                db.Inicidencias.Add(inicidencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TareaID = new SelectList(db.Tareas, "TareaID", "asunto", inicidencia.TareaID);
            return View(inicidencia);
        }

        // GET: Inicidencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inicidencia inicidencia = db.Inicidencias.Find(id);
            if (inicidencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.TareaID = new SelectList(db.Tareas, "TareaID", "asunto", inicidencia.TareaID);
            return View(inicidencia);
        }

        // POST: Inicidencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncidenciaID,Descripcion,TareaID")] Inicidencia inicidencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inicidencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TareaID = new SelectList(db.Tareas, "TareaID", "asunto", inicidencia.TareaID);
            return View(inicidencia);
        }

        // GET: Inicidencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inicidencia inicidencia = db.Inicidencias.Find(id);
            if (inicidencia == null)
            {
                return HttpNotFound();
            }
            return View(inicidencia);
        }

        // POST: Inicidencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inicidencia inicidencia = db.Inicidencias.Find(id);
            db.Inicidencias.Remove(inicidencia);
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
