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
    public class RoundThreeLeagueRoutesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RoundThreeLeagueRoutesApi
        public IQueryable<RoundThreeLeagueRoute> GetRoundThreeLeagueRoutes()
        {
            return db.RoundThreeLeagueRoutes.OrderByDescending(one => one.Ranking);
        }

        // GET: api/RoundThreeLeagueRoutesApi/5
        [ResponseType(typeof(RoundThreeLeagueRoute))]
        public IHttpActionResult GetRoundThreeLeagueRoute(int id)
        {
            RoundThreeLeagueRoute roundThreeLeagueRoute = db.RoundThreeLeagueRoutes.Find(id);
            if (roundThreeLeagueRoute == null)
            {
                return NotFound();
            }

            return Ok(roundThreeLeagueRoute);
        }

        // PUT: api/RoundThreeLeagueRoutesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoundThreeLeagueRoute(int id, RoundThreeLeagueRoute roundThreeLeagueRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roundThreeLeagueRoute.Id)
            {
                return BadRequest();
            }

            db.Entry(roundThreeLeagueRoute).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundThreeLeagueRouteExists(id))
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

        // POST: api/RoundThreeLeagueRoutesApi
        [ResponseType(typeof(RoundThreeLeagueRoute))]
        public IHttpActionResult PostRoundThreeLeagueRoute(RoundThreeLeagueRoute roundThreeLeagueRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoundThreeLeagueRoutes.Add(roundThreeLeagueRoute);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roundThreeLeagueRoute.Id }, roundThreeLeagueRoute);
        }

        // DELETE: api/RoundThreeLeagueRoutesApi/5
        [ResponseType(typeof(RoundThreeLeagueRoute))]
        public IHttpActionResult DeleteRoundThreeLeagueRoute(int id)
        {
            RoundThreeLeagueRoute roundThreeLeagueRoute = db.RoundThreeLeagueRoutes.Find(id);
            if (roundThreeLeagueRoute == null)
            {
                return NotFound();
            }

            db.RoundThreeLeagueRoutes.Remove(roundThreeLeagueRoute);
            db.SaveChanges();

            return Ok(roundThreeLeagueRoute);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundThreeLeagueRouteExists(int id)
        {
            return db.RoundThreeLeagueRoutes.Count(e => e.Id == id) > 0;
        }
    }
}