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

namespace UefaServiceV9.Controllers.API.Team_Ranking
{
    public class TeamRankingsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TeamRankingsApi
        public IQueryable<TeamRanking> GetTeamRankings()
        {
            return db.TeamRankings.OrderByDescending(one => one.Ranking);
        }

        // GET: api/TeamRankingsApi/5
        [ResponseType(typeof(TeamRanking))]
        public IHttpActionResult GetTeamRanking(int id)
        {
            TeamRanking teamRanking = db.TeamRankings.Find(id);
            if (teamRanking == null)
            {
                return NotFound();
            }

            return Ok(teamRanking);
        }

        // PUT: api/TeamRankingsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeamRanking(int id, TeamRanking teamRanking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teamRanking.Id)
            {
                return BadRequest();
            }

            db.Entry(teamRanking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamRankingExists(id))
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

        // POST: api/TeamRankingsApi
        [ResponseType(typeof(TeamRanking))]
        public IHttpActionResult PostTeamRanking(TeamRanking teamRanking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeamRankings.Add(teamRanking);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teamRanking.Id }, teamRanking);
        }

        // DELETE: api/TeamRankingsApi/5
        [ResponseType(typeof(TeamRanking))]
        public IHttpActionResult DeleteTeamRanking(int id)
        {
            TeamRanking teamRanking = db.TeamRankings.Find(id);
            if (teamRanking == null)
            {
                return NotFound();
            }

            db.TeamRankings.Remove(teamRanking);
            db.SaveChanges();

            return Ok(teamRanking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamRankingExists(int id)
        {
            return db.TeamRankings.Count(e => e.Id == id) > 0;
        }
    }
}