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
    public class TeamRankingsController : ApiController
    {
        private UefaServiceV4Context db = new UefaServiceV4Context();

        // GET: api/TeamRankings
        public IQueryable<TeamRanking> GetTeamRankings()
        {
            return db.TeamRankings;
        }

        // GET: api/TeamRankings/5
        [ResponseType(typeof(TeamRanking))]
        public async Task<IHttpActionResult> GetTeamRanking(int id)
        {
            TeamRanking teamRanking = await db.TeamRankings.FindAsync(id);
            if (teamRanking == null)
            {
                return NotFound();
            }

            return Ok(teamRanking);
        }

        // PUT: api/TeamRankings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeamRanking(int id, TeamRanking teamRanking)
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
                await db.SaveChangesAsync();
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

        // POST: api/TeamRankings
        [ResponseType(typeof(TeamRanking))]
        public async Task<IHttpActionResult> PostTeamRanking(TeamRanking teamRanking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeamRankings.Add(teamRanking);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = teamRanking.Id }, teamRanking);
        }

        // DELETE: api/TeamRankings/5
        [ResponseType(typeof(TeamRanking))]
        public async Task<IHttpActionResult> DeleteTeamRanking(int id)
        {
            TeamRanking teamRanking = await db.TeamRankings.FindAsync(id);
            if (teamRanking == null)
            {
                return NotFound();
            }

            db.TeamRankings.Remove(teamRanking);
            await db.SaveChangesAsync();

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