using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.API.Group_Stage
{
    public class GroupStagesApiController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IApplicationDbContext _db = new ApplicationDbContext();

        public GroupStagesApiController() //(IOrderedQueryable<GroupStage> orderByDescending)
        {

        }

         public GroupStagesApiController(IApplicationDbContext context)
        {
            _db = context;
        }


        // GET: api/GroupStagesApi
        public IQueryable<GroupStage> GetGroupStages()
        {
            return _db.GroupStages.OrderByDescending(one => one.Ranking);
        }

        // GET: api/GroupStagesApi/5
        [ResponseType(typeof(GroupStage))]
        public IHttpActionResult GetGroupStage(int id)
        {
            GroupStage groupStage = _db.GroupStages.Find(id);
            if (groupStage == null)
            {
                return NotFound();
            }

            return Ok(groupStage);
        }

        // PUT: api/GroupStagesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupStage(int id, GroupStage groupStage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupStage.Id)
            {
                return BadRequest();
            }

            //db.Entry(groupStage).State = EntityState.Modified;
            _db.MarkAsModified(groupStage);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupStageExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GroupStagesApi
        [ResponseType(typeof(GroupStage))]
        public IHttpActionResult PostGroupStage(GroupStage groupStage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.GroupStages.Add(groupStage);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = groupStage.Id }, groupStage);
        }

        // DELETE: api/GroupStagesApi/5
        [ResponseType(typeof(GroupStage))]
        public IHttpActionResult DeleteGroupStage(int id)
        {
            GroupStage groupStage = _db.GroupStages.Find(id);
            if (groupStage == null)
            {
                return NotFound();
            }

            _db.GroupStages.Remove(groupStage);
            _db.SaveChanges();

            return Ok(groupStage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupStageExists(int id)
        {
            return _db.GroupStages.Count(e => e.Id == id) > 0;
        }
    }
}