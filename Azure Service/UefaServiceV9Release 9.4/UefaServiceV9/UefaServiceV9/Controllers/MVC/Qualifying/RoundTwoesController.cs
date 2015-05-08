using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.MVC.Qualifying
{
    public class RoundTwoesController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: RoundTwoes
        public ActionResult Index()
        {
            return View(_db.RoundTwoes.OrderByDescending(one => one.Ranking));
        }

        // GET: RoundTwoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundTwo roundTwo = _db.RoundTwoes.Find(id);
            if (roundTwo == null)
            {
                return HttpNotFound();
            }
            return View(roundTwo);
        }

        // GET: RoundTwoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoundTwoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamName,CountryCode,Ranking")] RoundTwo roundTwo)
        {
            if (ModelState.IsValid)
            {
                _db.RoundTwoes.Add(roundTwo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roundTwo);
        }

        // GET: RoundTwoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundTwo roundTwo = _db.RoundTwoes.Find(id);
            if (roundTwo == null)
            {
                return HttpNotFound();
            }
            return View(roundTwo);
        }

        // POST: RoundTwoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamName,CountryCode,Ranking")] RoundTwo roundTwo)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(roundTwo).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roundTwo);
        }

        // GET: RoundTwoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundTwo roundTwo = _db.RoundTwoes.Find(id);
            if (roundTwo == null)
            {
                return HttpNotFound();
            }
            return View(roundTwo);
        }

        // POST: RoundTwoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoundTwo roundTwo = _db.RoundTwoes.Find(id);
            _db.RoundTwoes.Remove(roundTwo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
