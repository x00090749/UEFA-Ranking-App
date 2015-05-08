using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.API.Qualifying
{
    public class RoundFourLeagueRoutesApiController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IApplicationDbContext _db = new ApplicationDbContext();

         public RoundFourLeagueRoutesApiController()//(IOrderedQueryable<RoundFourLeagueRoute> orderByDescending)
        {

        }

        public RoundFourLeagueRoutesApiController(IApplicationDbContext context)
        {
            _db = context;
        }




        // GET: api/RoundFourLeagueRoutesApi
        public IQueryable<RoundFourLeagueRoute> GetRoundFourLeagueRoutes()
        {
            return _db.RoundFourLeagueRoutes.OrderByDescending(one => one.Ranking);
        }

        // GET: api/RoundFourLeagueRoutesApi/5
        [ResponseType(typeof(RoundFourLeagueRoute))]
        public IHttpActionResult GetRoundFourLeagueRoute(int id)
        {
            RoundFourLeagueRoute roundFourLeagueRoute = _db.RoundFourLeagueRoutes.Find(id);
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

            //db.Entry(roundFourLeagueRoute).State = EntityState.Modified;
            _db.MarkAsModified(roundFourLeagueRoute);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundFourLeagueRouteExists(id))
                {
                    return NotFound();
                }
                throw;
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

            _db.RoundFourLeagueRoutes.Add(roundFourLeagueRoute);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roundFourLeagueRoute.Id }, roundFourLeagueRoute);
        }

        // DELETE: api/RoundFourLeagueRoutesApi/5
        [ResponseType(typeof(RoundFourLeagueRoute))]
        public IHttpActionResult DeleteRoundFourLeagueRoute(int id)
        {
            RoundFourLeagueRoute roundFourLeagueRoute = _db.RoundFourLeagueRoutes.Find(id);
            if (roundFourLeagueRoute == null)
            {
                return NotFound();
            }

            _db.RoundFourLeagueRoutes.Remove(roundFourLeagueRoute);
            _db.SaveChanges();

            return Ok(roundFourLeagueRoute);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundFourLeagueRouteExists(int id)
        {
            return _db.RoundFourLeagueRoutes.Count(e => e.Id == id) > 0;
        }
    }
}