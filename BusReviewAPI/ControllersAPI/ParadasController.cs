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
    public class ParadasController : ApiController
    {
        private BusReview db = new BusReview();

        // GET: api/Paradas
        public IQueryable<Parada> GetParada()
        {
            return db.Parada;
        }

        // GET: api/Paradas/5
        [ResponseType(typeof(Parada))]
        public IHttpActionResult GetParada(int id)
        {
            Parada parada = db.Parada.Find(id);
            if (parada == null)
            {
                return NotFound();
            }

            return Ok(parada);
        }

        // PUT: api/Paradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParada(int id, Parada parada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parada.ParadaId)
            {
                return BadRequest();
            }

            db.Entry(parada).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParadaExists(id))
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

        // POST: api/Paradas
        [ResponseType(typeof(Parada))]
        public IHttpActionResult PostParada(Parada parada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parada.Add(parada);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = parada.ParadaId }, parada);
        }

        // DELETE: api/Paradas/5
        [ResponseType(typeof(Parada))]
        public IHttpActionResult DeleteParada(int id)
        {
            Parada parada = db.Parada.Find(id);
            if (parada == null)
            {
                return NotFound();
            }

            db.Parada.Remove(parada);
            db.SaveChanges();

            return Ok(parada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParadaExists(int id)
        {
            return db.Parada.Count(e => e.ParadaId == id) > 0;
        }
    }
}