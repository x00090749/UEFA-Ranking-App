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
    public class RoundTwoesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RoundTwoesApi
        public IQueryable<RoundTwo> GetRoundTwoes()
        {
            return db.RoundTwoes.OrderByDescending(one => one.Ranking);
        }

        // GET: api/RoundTwoesApi/5
        [ResponseType(typeof(RoundTwo))]
        public IHttpActionResult GetRoundTwo(int id)
        {
            RoundTwo roundTwo = db.RoundTwoes.Find(id);
            if (roundTwo == null)
            {
                return NotFound();
            }

            return Ok(roundTwo);
        }

        // PUT: api/RoundTwoesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoundTwo(int id, RoundTwo roundTwo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roundTwo.Id)
            {
                return BadRequest();
            }

            db.Entry(roundTwo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundTwoExists(id))
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

        // POST: api/RoundTwoesApi
        [ResponseType(typeof(RoundTwo))]
        public IHttpActionResult PostRoundTwo(RoundTwo roundTwo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoundTwoes.Add(roundTwo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roundTwo.Id }, roundTwo);
        }

        // DELETE: api/RoundTwoesApi/5
        [ResponseType(typeof(RoundTwo))]
        public IHttpActionResult DeleteRoundTwo(int id)
        {
            RoundTwo roundTwo = db.RoundTwoes.Find(id);
            if (roundTwo == null)
            {
                return NotFound();
            }

            db.RoundTwoes.Remove(roundTwo);
            db.SaveChanges();

            return Ok(roundTwo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundTwoExists(int id)
        {
            return db.RoundTwoes.Count(e => e.Id == id) > 0;
        }
    }
}