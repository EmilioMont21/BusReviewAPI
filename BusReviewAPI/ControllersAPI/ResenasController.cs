using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusReviewAPI.Models;

namespace BusReviewAPI.ControllersAPI
{
    public class ResenasController : ApiController
    {
        private BusReview db = new BusReview();

        // GET: api/Resenas
        public IQueryable<Resena> GetResena()
        {
            return db.Resena;
        }

        // GET: api/Resenas/5
        [ResponseType(typeof(Resena))]
        public IHttpActionResult GetResena(int id)
        {
            Resena resena = db.Resena.Find(id);
            if (resena == null)
            {
                return NotFound();
            }

            return Ok(resena);
        }

        // PUT: api/Resenas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResena(int id, Resena resena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resena.ResenaId)
            {
                return BadRequest();
            }

            db.Entry(resena).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResenaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Resenas
        [ResponseType(typeof(Resena))]
        public IHttpActionResult PostResena(Resena resena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Resena.Add(resena);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resena.ResenaId }, resena);
        }

        // DELETE: api/Resenas/5
        [ResponseType(typeof(Resena))]
        public IHttpActionResult DeleteResena(int id)
        {
            Resena resena = db.Resena.Find(id);
            if (resena == null)
            {
                return NotFound();
            }

            db.Resena.Remove(resena);
            db.SaveChanges();

            return Ok(resena);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResenaExists(int id)
        {
            return db.Resena.Count(e => e.ResenaId == id) > 0;
        }
    }
}