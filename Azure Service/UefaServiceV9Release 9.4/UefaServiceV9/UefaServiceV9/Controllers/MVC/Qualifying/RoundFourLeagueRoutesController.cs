using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.MVC.Qualifying
{
    public class RoundFourLeagueRoutesController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: RoundFourLeagueRoutes
        public ActionResult Index()
        {
            return View(_db.RoundFourLeagueRoutes.OrderByDescending(one => one.Ranking));
        }

        // GET: RoundFourLeagueRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundFourLeagueRoute roundFourLeagueRoute = _db.RoundFourLeagueRoutes.Find(id);
            if (roundFourLeagueRoute == null)
            {
                return HttpNotFound();
            }
            return View(roundFourLeagueRoute);
        }

        // GET: RoundFourLeagueRoutes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoundFourLeagueRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamName,CountryCode,Ranking")] RoundFourLeagueRoute roundFourLeagueRoute)
        {
            if (ModelState.IsValid)
            {
                _db.RoundFourLeagueRoutes.Add(roundFourLeagueRoute);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roundFourLeagueRoute);
        }

        // GET: RoundFourLeagueRoutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundFourLeagueRoute roundFourLeagueRoute = _db.RoundFourLeagueRoutes.Find(id);
            if (roundFourLeagueRoute == null)
            {
                return HttpNotFound();
            }
            return View(roundFourLeagueRoute);
        }

        // POST: RoundFourLeagueRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamName,CountryCode,Ranking")] RoundFourLeagueRoute roundFourLeagueRoute)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(roundFourLeagueRoute).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roundFourLeagueRoute);
        }

        // GET: RoundFourLeagueRoutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundFourLeagueRoute roundFourLeagueRoute = _db.RoundFourLeagueRoutes.Find(id);
            if (roundFourLeagueRoute == null)
            {
                return HttpNotFound();
            }
            return View(roundFourLeagueRoute);
        }

        // POST: RoundFourLeagueRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoundFourLeagueRoute roundFourLeagueRoute = _db.RoundFourLeagueRoutes.Find(id);
            _db.RoundFourLeagueRoutes.Remove(roundFourLeagueRoute);
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
