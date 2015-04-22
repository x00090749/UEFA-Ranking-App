using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.MVC.Qualifying
{
    public class RoundFourLeagueRoutesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoundFourLeagueRoutes
        public ActionResult Index()
        {
            return View(db.RoundFourLeagueRoutes.ToList());
        }

        // GET: RoundFourLeagueRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundFourLeagueRoute roundFourLeagueRoute = db.RoundFourLeagueRoutes.Find(id);
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
        public ActionResult Create([Bind(Include = "Id,TeamName,CountryCode,Ranking,TeamRankingId")] RoundFourLeagueRoute roundFourLeagueRoute)
        {
            if (ModelState.IsValid)
            {
                db.RoundFourLeagueRoutes.Add(roundFourLeagueRoute);
                db.SaveChanges();
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
            RoundFourLeagueRoute roundFourLeagueRoute = db.RoundFourLeagueRoutes.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,TeamName,CountryCode,Ranking,TeamRankingId")] RoundFourLeagueRoute roundFourLeagueRoute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roundFourLeagueRoute).State = EntityState.Modified;
                db.SaveChanges();
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
            RoundFourLeagueRoute roundFourLeagueRoute = db.RoundFourLeagueRoutes.Find(id);
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
            RoundFourLeagueRoute roundFourLeagueRoute = db.RoundFourLeagueRoutes.Find(id);
            db.RoundFourLeagueRoutes.Remove(roundFourLeagueRoute);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
