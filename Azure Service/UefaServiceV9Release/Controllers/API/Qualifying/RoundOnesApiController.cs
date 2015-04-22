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
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.API.Qualifying
{
    public class RoundOnesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RoundOnesApi
        public IQueryable<RoundOne> GetRoundOnes()
        {

            return db.RoundOnes.OrderBy(one => one.Ranking);
        }

        // GET: api/RoundOnesApi/5
        [ResponseType(typeof(RoundOne))]
        public IHttpActionResult GetRoundOne(int id)
        {
            RoundOne roundOne = db.RoundOnes.Find(id);
            if (roundOne == null)
            {
                return NotFound();
            }

            return Ok(roundOne);
        }

        // PUT: api/RoundOnesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoundOne(int id, RoundOne roundOne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roundOne.Id)
            {
                return BadRequest();
            }

            db.Entry(roundOne).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundOneExists(id))
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

        // POST: api/RoundOnesApi
        [ResponseType(typeof(RoundOne))]
        public IHttpActionResult PostRoundOne(RoundOne roundOne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoundOnes.Add(roundOne);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roundOne.Id }, roundOne);
        }

        // DELETE: api/RoundOnesApi/5
        [ResponseType(typeof(RoundOne))]
        public IHttpActionResult DeleteRoundOne(int id)
        {
            RoundOne roundOne = db.RoundOnes.Find(id);
            if (roundOne == null)
            {
                return NotFound();
            }

            db.RoundOnes.Remove(roundOne);
            db.SaveChanges();

            return Ok(roundOne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundOneExists(int id)
        {
            return db.RoundOnes.Count(e => e.Id == id) > 0;
        }
    }
}