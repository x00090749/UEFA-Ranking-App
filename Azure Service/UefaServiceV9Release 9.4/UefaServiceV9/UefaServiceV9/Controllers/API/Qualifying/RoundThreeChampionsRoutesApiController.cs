using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.API.Qualifying
{
    public class RoundThreeChampionsRoutesApiController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IApplicationDbContext _db = new ApplicationDbContext();

         public RoundThreeChampionsRoutesApiController()//(IOrderedQueryable<RoundThreeChampionsRoute> orderByDescending)
        {

        }

        public RoundThreeChampionsRoutesApiController(IApplicationDbContext context)
        {
            _db = context;
        }

        // GET: api/RoundThreeChampionsRoutesApi
        public IQueryable<RoundThreeChampionsRoute> GetRoundThreeChampionsRoutes()
        {
            return _db.RoundThreeChampionsRoutes.OrderByDescending(one => one.Ranking);
        }

        // GET: api/RoundThreeChampionsRoutesApi/5
        [ResponseType(typeof(RoundThreeChampionsRoute))]
        public IHttpActionResult GetRoundThreeChampionsRoute(int id)
        {
            RoundThreeChampionsRoute roundThreeChampionsRoute = _db.RoundThreeChampionsRoutes.Find(id);
            if (roundThreeChampionsRoute == null)
            {
                return NotFound();
            }

            return Ok(roundThreeChampionsRoute);
        }

        // PUT: api/RoundThreeChampionsRoutesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoundThreeChampionsRoute(int id, RoundThreeChampionsRoute roundThreeChampionsRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roundThreeChampionsRoute.Id)
            {
                return BadRequest();
            }

            //db.Entry(roundThreeChampionsRoute).State = EntityState.Modified;
            _db.MarkAsModified(roundThreeChampionsRoute);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundThreeChampionsRouteExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RoundThreeChampionsRoutesApi
        [ResponseType(typeof(RoundThreeChampionsRoute))]
        public IHttpActionResult PostRoundThreeChampionsRoute(RoundThreeChampionsRoute roundThreeChampionsRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.RoundThreeChampionsRoutes.Add(roundThreeChampionsRoute);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roundThreeChampionsRoute.Id }, roundThreeChampionsRoute);
        }

        // DELETE: api/RoundThreeChampionsRoutesApi/5
        [ResponseType(typeof(RoundThreeChampionsRoute))]
        public IHttpActionResult DeleteRoundThreeChampionsRoute(int id)
        {
            RoundThreeChampionsRoute roundThreeChampionsRoute = _db.RoundThreeChampionsRoutes.Find(id);
            if (roundThreeChampionsRoute == null)
            {
                return NotFound();
            }

            _db.RoundThreeChampionsRoutes.Remove(roundThreeChampionsRoute);
            _db.SaveChanges();

            return Ok(roundThreeChampionsRoute);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundThreeChampionsRouteExists(int id)
        {
            return _db.RoundThreeChampionsRoutes.Count(e => e.Id == id) > 0;
        }
    }
}