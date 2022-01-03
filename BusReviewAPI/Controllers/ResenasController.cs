using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusReviewAPI.Models;

namespace BusReviewAPI.Controllers
{
    public class ResenasController : Controller
    {
        private BusReview db = new BusReview();

        // GET: Resenas
        public ActionResult Index()
        {
            return View(db.Resena.ToList());
        }

        // GET: Resenas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resena resena = db.Resena.Find(id);
            if (resena == null)
            {
                return HttpNotFound();
            }
            return View(resena);
        }

        // GET: Resenas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resenas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResenaId,Usuario,Placa,Calificacion,Nota")] Resena resena)
        {
            if (ModelState.IsValid)
            {
                db.Resena.Add(resena);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resena);
        }

        // GET: Resenas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resena resena = db.Resena.Find(id);
            if (resena == null)
            {
                return HttpNotFound();
            }
            return View(resena);
        }

        // POST: Resenas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResenaId,Usuario,Placa,Calificacion,Nota")] Resena resena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resena).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resena);
        }

        // GET: Resenas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resena resena = db.Resena.Find(id);
            if (resena == null)
            {
                return HttpNotFound();
            }
            return View(resena);
        }

        // POST: Resenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resena resena = db.Resena.Find(id);
            db.Resena.Remove(resena);
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
