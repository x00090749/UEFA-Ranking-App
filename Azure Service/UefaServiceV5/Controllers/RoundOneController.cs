using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using UefaServiceV4.Models;

namespace UefaServiceV4.Controllers
{
    public class RoundOneController : ApiController
    {
        private UefaServiceV4Context db = new UefaServiceV4Context();

        // GET: api/RoundOne
        public IQueryable<RoundOne> GetRoundOnes()
        {
            return db.RoundOnes;
        }

        // GET: api/RoundOne/5
        [ResponseType(typeof(RoundOne))]
        public async Task<IHttpActionResult> GetRoundOne(int id)
        {
            RoundOne roundOne = await db.RoundOnes.FindAsync(id);
            if (roundOne == null)
            {
                return NotFound();
            }

            return Ok(roundOne);
        }

        // PUT: api/RoundOne/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRoundOne(int id, RoundOne roundOne)
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
                await db.SaveChangesAsync();
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

        // POST: api/RoundOne
        [ResponseType(typeof(RoundOne))]
        public async Task<IHttpActionResult> PostRoundOne(RoundOne roundOne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoundOnes.Add(roundOne);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = roundOne.Id }, roundOne);
        }

        // DELETE: api/RoundOne/5
        [ResponseType(typeof(RoundOne))]
        public async Task<IHttpActionResult> DeleteRoundOne(int id)
        {
            RoundOne roundOne = await db.RoundOnes.FindAsync(id);
            if (roundOne == null)
            {
                return NotFound();
            }

            db.RoundOnes.Remove(roundOne);
            await db.SaveChangesAsync();

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