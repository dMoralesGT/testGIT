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
    public class TareaController : Controller
    {
        private ProyectContext db = new ProyectContext();

        // GET: Tarea
        public ActionResult Index()
        {
            var tareas = db.Tareas.Include(t => t.Categoria).Include(t => t.Desarrollador).Include(t => t.Estado).Include(t => t.Prioridad).Include(t => t.Proyecto);
            return View(tareas.ToList());
        }

        // GET: Tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tareas.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // GET: Tarea/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nombre");
            ViewBag.DesarrolladorID = new SelectList(db.Desarrolladores, "DesarrolladorID", "Nombre");
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");
            ViewBag.PrioridadID = new SelectList(db.Prioridades, "PrioridadID", "Descripcion");
            ViewBag.ProyectoID = new SelectList(db.Proyectos, "ProyectoID", "Nombre");
            return View();
        }

        // POST: Tarea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TareaID,asunto,cuerpo,fechaCreacion,tiempoEstimado,DesarrolladorID,ProyectoID,PrioridadID,EstadoID,CategoriaID")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Tareas.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nombre", tarea.CategoriaID);
            ViewBag.DesarrolladorID = new SelectList(db.Desarrolladores, "DesarrolladorID", "Nombre", tarea.DesarrolladorID);
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tarea.EstadoID);
            ViewBag.PrioridadID = new SelectList(db.Prioridades, "PrioridadID", "Descripcion", tarea.PrioridadID);
            ViewBag.ProyectoID = new SelectList(db.Proyectos, "ProyectoID", "Nombre", tarea.ProyectoID);
            return View(tarea);
        }

        // GET: Tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tareas.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nombre", tarea.CategoriaID);
            ViewBag.DesarrolladorID = new SelectList(db.Desarrolladores, "DesarrolladorID", "Nombre", tarea.DesarrolladorID);
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tarea.EstadoID);
            ViewBag.PrioridadID = new SelectList(db.Prioridades, "PrioridadID", "Descripcion", tarea.PrioridadID);
            ViewBag.ProyectoID = new SelectList(db.Proyectos, "ProyectoID", "Nombre", tarea.ProyectoID);
            return View(tarea);
        }

        // POST: Tarea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TareaID,asunto,cuerpo,fechaCreacion,tiempoEstimado,DesarrolladorID,ProyectoID,PrioridadID,EstadoID,CategoriaID")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nombre", tarea.CategoriaID);
            ViewBag.DesarrolladorID = new SelectList(db.Desarrolladores, "DesarrolladorID", "Nombre", tarea.DesarrolladorID);
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre", tarea.EstadoID);
            ViewBag.PrioridadID = new SelectList(db.Prioridades, "PrioridadID", "Descripcion", tarea.PrioridadID);
            ViewBag.ProyectoID = new SelectList(db.Proyectos, "ProyectoID", "Nombre", tarea.ProyectoID);
            return View(tarea);
        }

        // GET: Tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tareas.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: Tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarea tarea = db.Tareas.Find(id);
            db.Tareas.Remove(tarea);
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
