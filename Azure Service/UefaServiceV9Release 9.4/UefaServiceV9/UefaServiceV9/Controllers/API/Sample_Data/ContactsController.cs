using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.API.Sample_Data
{
    public class ContactsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        [AllowAnonymous]
        // GET: api/Contacts
        public IQueryable<Contact> GetContacts()
        {
            return _db.Contacts;
        }
        [AllowAnonymous]
        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            Contact contact = _db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }


        // PUT: api/Contacts/5
        [Authorize(Roles = "canEdit")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ContactId)
            {
                return BadRequest();
            }

            _db.Entry(contact).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        [Authorize(Roles = "canEdit")]
        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Contacts.Add(contact);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contact.ContactId }, contact);
        }

        // DELETE: api/Contacts/5
        [Authorize(Roles = "canEdit")]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = _db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            _db.Contacts.Remove(contact);
            _db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return _db.Contacts.Count(e => e.ContactId == id) > 0;
        }
    }
}