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
    public class ParadasController : Controller
    {
        private BusReview db = new BusReview();

        // GET: Paradas
        public ActionResult Index()
        {
            return View(db.Parada.ToList());
        }

        // GET: Paradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parada parada = db.Parada.Find(id);
            if (parada == null)
            {
                return HttpNotFound();
            }
            return View(parada);
        }

        // GET: Paradas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paradas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParadaId,Nombre,Sector,Callep,Calles,Costo")] Parada parada)
        {
            if (ModelState.IsValid)
            {
                db.Parada.Add(parada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parada);
        }

        // GET: Paradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parada parada = db.Parada.Find(id);
            if (parada == null)
            {
                return HttpNotFound();
            }
            return View(parada);
        }

        // POST: Paradas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParadaId,Nombre,Sector,Callep,Calles,Costo")] Parada parada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parada);
        }

        // GET: Paradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parada parada = db.Parada.Find(id);
            if (parada == null)
            {
                return HttpNotFound();
            }
            return View(parada);
        }

        // POST: Paradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parada parada = db.Parada.Find(id);
            db.Parada.Remove(parada);
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
