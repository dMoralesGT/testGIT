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
    public class PrioridadController : Controller
    {
        private ProyectContext db = new ProyectContext();

        // GET: Prioridad
        public ActionResult Index()
        {
            return View(db.Prioridades.ToList());
        }

        // GET: Prioridad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridad prioridad = db.Prioridades.Find(id);
            if (prioridad == null)
            {
                return HttpNotFound();
            }
            return View(prioridad);
        }

        // GET: Prioridad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prioridad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrioridadID,Descripcion")] Prioridad prioridad)
        {
            if (ModelState.IsValid)
            {
                db.Prioridades.Add(prioridad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prioridad);
        }

        // GET: Prioridad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridad prioridad = db.Prioridades.Find(id);
            if (prioridad == null)
            {
                return HttpNotFound();
            }
            return View(prioridad);
        }

        // POST: Prioridad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrioridadID,Descripcion")] Prioridad prioridad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prioridad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prioridad);
        }

        // GET: Prioridad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridad prioridad = db.Prioridades.Find(id);
            if (prioridad == null)
            {
                return HttpNotFound();
            }
            return View(prioridad);
        }

        // POST: Prioridad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prioridad prioridad = db.Prioridades.Find(id);
            db.Prioridades.Remove(prioridad);
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
