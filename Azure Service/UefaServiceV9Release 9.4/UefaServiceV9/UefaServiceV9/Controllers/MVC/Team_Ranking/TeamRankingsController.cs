using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.MVC.Team_Ranking
{
    public class TeamRankingsController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: TeamRankings
        public ActionResult Index()
        {
            return View(_db.TeamRankings.OrderByDescending(one => one.Ranking));
            
        }

        // GET: TeamRankings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamRanking teamRanking = _db.TeamRankings.Find(id);
            if (teamRanking == null)
            {
                return HttpNotFound();
            }
            return View(teamRanking);
        }

        // GET: TeamRankings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamRankings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RankPosition,TeamName,CountryCode,Ranking")] TeamRanking teamRanking)
        {
            if (ModelState.IsValid)
            {
                _db.TeamRankings.Add(teamRanking);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamRanking);
        }

        // GET: TeamRankings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamRanking teamRanking = _db.TeamRankings.Find(id);
            if (teamRanking == null)
            {
                return HttpNotFound();
            }
            return View(teamRanking);
        }

        // POST: TeamRankings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RankPosition,TeamName,CountryCode,Ranking")] TeamRanking teamRanking)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(teamRanking).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamRanking);
        }

        // GET: TeamRankings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamRanking teamRanking = _db.TeamRankings.Find(id);
            if (teamRanking == null)
            {
                return HttpNotFound();
            }
            return View(teamRanking);
        }

        // POST: TeamRankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamRanking teamRanking = _db.TeamRankings.Find(id);
            _db.TeamRankings.Remove(teamRanking);
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
