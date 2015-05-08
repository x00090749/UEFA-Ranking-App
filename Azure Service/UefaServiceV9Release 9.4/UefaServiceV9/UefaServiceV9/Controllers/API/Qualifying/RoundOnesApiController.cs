using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.API.Qualifying
{
    public class RoundOnesApiController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IApplicationDbContext _db = new ApplicationDbContext();

        public RoundOnesApiController()//(IOrderedQueryable<RoundOne> orderByDescending)
        {

        }

        public RoundOnesApiController(IApplicationDbContext context)
        {
            _db = context;
        }

        // GET: api/RoundOnesApi
        public IQueryable<RoundOne> GetRoundOnes()
        {
            return _db.RoundOnes.OrderByDescending(one => one.Ranking);
            //return db.RoundOnes;
        }

        // GET: api/RoundOnesApi/5
        [ResponseType(typeof(RoundOne))]
        public IHttpActionResult GetRoundOne(int id)
        {
            RoundOne roundOne = _db.RoundOnes.Find(id);
            if (roundOne == null)
            {
                return NotFound();
            }

            return Ok(roundOne);
        }

        // PUT: api/RoundOnesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoundOne(int id, RoundOne roundOne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roundOne.Id)
            {
                return BadRequest();
            }

            //db.Entry(roundOne).State = EntityState.Modified;
            _db.MarkAsModified(roundOne);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundOneExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
       
        // POST: api/RoundOnesApi
        [ResponseType(typeof(RoundOne))]
        public IHttpActionResult PostRoundOne(RoundOne roundOne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.RoundOnes.Add(roundOne);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roundOne.Id }, roundOne);
        }

        // DELETE: api/RoundOnesApi/5
        [ResponseType(typeof(RoundOne))]
        public IHttpActionResult DeleteRoundOne(int id)
        {
            RoundOne roundOne = _db.RoundOnes.Find(id);
            if (roundOne == null)
            {
                return NotFound();
            }

            _db.RoundOnes.Remove(roundOne);
            _db.SaveChanges();

            return Ok(roundOne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundOneExists(int id)
        {
            return _db.RoundOnes.Count(e => e.Id == id) > 0;
        }
    }
}