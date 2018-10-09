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
    public class DesarrolladorController : Controller
    {
        private ProyectContext db = new ProyectContext();

        // GET: Desarrollador
        public ActionResult Index()
        {
            return View(db.Desarrolladores.ToList());
        }

        // GET: Desarrollador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desarrollador desarrollador = db.Desarrolladores.Find(id);
            if (desarrollador == null)
            {
                return HttpNotFound();
            }
            return View(desarrollador);
        }

        // GET: Desarrollador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Desarrollador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesarrolladorID,Nombre,Admin")] Desarrollador desarrollador)
        {
            if (ModelState.IsValid)
            {
                db.Desarrolladores.Add(desarrollador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(desarrollador);
        }

        // GET: Desarrollador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desarrollador desarrollador = db.Desarrolladores.Find(id);
            if (desarrollador == null)
            {
                return HttpNotFound();
            }
            return View(desarrollador);
        }

        // POST: Desarrollador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DesarrolladorID,Nombre,Admin")] Desarrollador desarrollador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desarrollador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(desarrollador);
        }

        // GET: Desarrollador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desarrollador desarrollador = db.Desarrolladores.Find(id);
            if (desarrollador == null)
            {
                return HttpNotFound();
            }
            return View(desarrollador);
        }

        // POST: Desarrollador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Desarrollador desarrollador = db.Desarrolladores.Find(id);
            db.Desarrolladores.Remove(desarrollador);
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
