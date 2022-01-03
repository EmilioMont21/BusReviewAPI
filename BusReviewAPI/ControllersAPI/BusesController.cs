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
    public class BusesController : ApiController
    {
        private BusReview db = new BusReview();

        // GET: api/Buses
        public IQueryable<Bus> GetBus()
        {
            return db.Bus;
        }

        // GET: api/Buses/5
        [ResponseType(typeof(Bus))]
        public IHttpActionResult GetBus(int id)
        {
            Bus bus = db.Bus.Find(id);
            if (bus == null)
            {
                return NotFound();
            }

            return Ok(bus);
        }

        // PUT: api/Buses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBus(int id, Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bus.BusId)
            {
                return BadRequest();
            }

            db.Entry(bus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
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

        // POST: api/Buses
        [ResponseType(typeof(Bus))]
        public IHttpActionResult PostBus(Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bus.Add(bus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bus.BusId }, bus);
        }

        // DELETE: api/Buses/5
        [ResponseType(typeof(Bus))]
        public IHttpActionResult DeleteBus(int id)
        {
            Bus bus = db.Bus.Find(id);
            if (bus == null)
            {
                return NotFound();
            }

            db.Bus.Remove(bus);
            db.SaveChanges();

            return Ok(bus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusExists(int id)
        {
            return db.Bus.Count(e => e.BusId == id) > 0;
        }
    }
}