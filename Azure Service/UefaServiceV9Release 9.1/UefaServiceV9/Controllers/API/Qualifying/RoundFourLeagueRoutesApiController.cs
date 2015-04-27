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
    public class RoundFourLeagueRoutesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RoundFourLeagueRoutesApi
        public IQueryable<RoundFourLeagueRoute> GetRoundFourLeagueRoutes()
        {
            return db.RoundFourLeagueRoutes.OrderByDescending(one => one.Ranking);
        }

        // GET: api/RoundFourLeagueRoutesApi/5
        [ResponseType(typeof(RoundFourLeagueRoute))]
        public IHttpActionResult GetRoundFourLeagueRoute(int id)
        {
            RoundFourLeagueRoute roundFourLeagueRoute = db.RoundFourLeagueRoutes.Find(id);
            if (roundFourLeagueRoute == null)
            {
                return NotFound();
            }

            return Ok(roundFourLeagueRoute);
        }

        // PUT: api/RoundFourLeagueRoutesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoundFourLeagueRoute(int id, RoundFourLeagueRoute roundFourLeagueRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roundFourLeagueRoute.Id)
            {
                return BadRequest();
            }

            db.Entry(roundFourLeagueRoute).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundFourLeagueRouteExists(id))
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

        // POST: api/RoundFourLeagueRoutesApi
        [ResponseType(typeof(RoundFourLeagueRoute))]
        public IHttpActionResult PostRoundFourLeagueRoute(RoundFourLeagueRoute roundFourLeagueRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoundFourLeagueRoutes.Add(roundFourLeagueRoute);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roundFourLeagueRoute.Id }, roundFourLeagueRoute);
        }

        // DELETE: api/RoundFourLeagueRoutesApi/5
        [ResponseType(typeof(RoundFourLeagueRoute))]
        public IHttpActionResult DeleteRoundFourLeagueRoute(int id)
        {
            RoundFourLeagueRoute roundFourLeagueRoute = db.RoundFourLeagueRoutes.Find(id);
            if (roundFourLeagueRoute == null)
            {
                return NotFound();
            }

            db.RoundFourLeagueRoutes.Remove(roundFourLeagueRoute);
            db.SaveChanges();

            return Ok(roundFourLeagueRoute);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundFourLeagueRouteExists(int id)
        {
            return db.RoundFourLeagueRoutes.Count(e => e.Id == id) > 0;
        }
    }
}