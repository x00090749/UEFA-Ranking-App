using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.API.Qualifying
{
    public class RoundThreeLeagueRoutesApiController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IApplicationDbContext _db = new ApplicationDbContext();

        public RoundThreeLeagueRoutesApiController()//(IOrderedQueryable<RoundThreeLeagueRoute> orderByDescending)
        {

        }

        public RoundThreeLeagueRoutesApiController(IApplicationDbContext context)
        {
            _db = context;
        }


        // GET: api/RoundThreeLeagueRoutesApi
        public IQueryable<RoundThreeLeagueRoute> GetRoundThreeLeagueRoutes()
        {
            return _db.RoundThreeLeagueRoutes.OrderByDescending(one => one.Ranking);
        }

        // GET: api/RoundThreeLeagueRoutesApi/5
        [ResponseType(typeof(RoundThreeLeagueRoute))]
        public IHttpActionResult GetRoundThreeLeagueRoute(int id)
        {
            RoundThreeLeagueRoute roundThreeLeagueRoute = _db.RoundThreeLeagueRoutes.Find(id);
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

            //db.Entry(roundThreeLeagueRoute).State = EntityState.Modified;
            _db.MarkAsModified(roundThreeLeagueRoute);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundThreeLeagueRouteExists(id))
                {
                    return NotFound();
                }
                    throw;
                
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

            _db.RoundThreeLeagueRoutes.Add(roundThreeLeagueRoute);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roundThreeLeagueRoute.Id }, roundThreeLeagueRoute);
        }

        // DELETE: api/RoundThreeLeagueRoutesApi/5
        [ResponseType(typeof(RoundThreeLeagueRoute))]
        public IHttpActionResult DeleteRoundThreeLeagueRoute(int id)
        {
            RoundThreeLeagueRoute roundThreeLeagueRoute = _db.RoundThreeLeagueRoutes.Find(id);
            if (roundThreeLeagueRoute == null)
            {
                return NotFound();
            }

            _db.RoundThreeLeagueRoutes.Remove(roundThreeLeagueRoute);
            _db.SaveChanges();

            return Ok(roundThreeLeagueRoute);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundThreeLeagueRouteExists(int id)
        {
            return _db.RoundThreeLeagueRoutes.Count(e => e.Id == id) > 0;
        }
    }
}