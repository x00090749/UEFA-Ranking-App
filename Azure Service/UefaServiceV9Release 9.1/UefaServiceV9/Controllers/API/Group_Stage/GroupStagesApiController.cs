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

namespace UefaServiceV9.Controllers.API.Group_Stage
{
    public class GroupStagesApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/GroupStagesApi
        public IQueryable<GroupStage> GetGroupStages()
        {
            return db.GroupStages.OrderByDescending(one => one.Ranking);
        }

        // GET: api/GroupStagesApi/5
        [ResponseType(typeof(GroupStage))]
        public IHttpActionResult GetGroupStage(int id)
        {
            GroupStage groupStage = db.GroupStages.Find(id);
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

            db.Entry(groupStage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupStageExists(id))
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

        // POST: api/GroupStagesApi
        [ResponseType(typeof(GroupStage))]
        public IHttpActionResult PostGroupStage(GroupStage groupStage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupStages.Add(groupStage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = groupStage.Id }, groupStage);
        }

        // DELETE: api/GroupStagesApi/5
        [ResponseType(typeof(GroupStage))]
        public IHttpActionResult DeleteGroupStage(int id)
        {
            GroupStage groupStage = db.GroupStages.Find(id);
            if (groupStage == null)
            {
                return NotFound();
            }

            db.GroupStages.Remove(groupStage);
            db.SaveChanges();

            return Ok(groupStage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupStageExists(int id)
        {
            return db.GroupStages.Count(e => e.Id == id) > 0;
        }
    }
}