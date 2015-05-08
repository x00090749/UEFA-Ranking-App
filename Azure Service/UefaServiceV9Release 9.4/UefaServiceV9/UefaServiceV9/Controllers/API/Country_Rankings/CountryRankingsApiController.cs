using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.API.Country_Rankings
{
    public class CountryRankingsApiController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IApplicationDbContext _db = new ApplicationDbContext();

        public CountryRankingsApiController()//(IOrderedQueryable<CountryRanking> orderByDescending)
        {

        }

        public CountryRankingsApiController(IApplicationDbContext context)
        {
            _db = context;
        }



        // GET: api/CountryRankingsApi
        public IQueryable<CountryRanking> GetCountryRankings()
        {
            return _db.CountryRankings.OrderByDescending(one => one.Ranking);
        }

        // GET: api/CountryRankingsApi/5
        [ResponseType(typeof(CountryRanking))]
        public IHttpActionResult GetCountryRanking(int id)
        {
            CountryRanking countryRanking = _db.CountryRankings.Find(id);
            if (countryRanking == null)
            {
                return NotFound();
            }

            return Ok(countryRanking);
        }

        // PUT: api/CountryRankingsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCountryRanking(int id, CountryRanking countryRanking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countryRanking.Id)
            {
                return BadRequest();
            }

            //db.Entry(countryRanking).State = EntityState.Modified;
            _db.MarkAsModified(countryRanking);
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryRankingExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CountryRankingsApi
        [ResponseType(typeof(CountryRanking))]
        public IHttpActionResult PostCountryRanking(CountryRanking countryRanking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.CountryRankings.Add(countryRanking);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = countryRanking.Id }, countryRanking);
        }

        // DELETE: api/CountryRankingsApi/5
        [ResponseType(typeof(CountryRanking))]
        public IHttpActionResult DeleteCountryRanking(int id)
        {
            CountryRanking countryRanking = _db.CountryRankings.Find(id);
            if (countryRanking == null)
            {
                return NotFound();
            }

            _db.CountryRankings.Remove(countryRanking);
            _db.SaveChanges();

            return Ok(countryRanking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryRankingExists(int id)
        {
            return _db.CountryRankings.Count(e => e.Id == id) > 0;
        }
    }
}