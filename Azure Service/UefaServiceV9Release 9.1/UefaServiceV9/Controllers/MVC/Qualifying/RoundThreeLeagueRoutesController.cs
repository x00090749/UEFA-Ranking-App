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
    public class RoundThreeLeagueRoutesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoundThreeLeagueRoutes
        public ActionResult Index()
        {
            return View(db.RoundThreeLeagueRoutes.OrderByDescending(one => one.Ranking));
        }

        // GET: RoundThreeLeagueRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundThreeLeagueRoute roundThreeLeagueRoute = db.RoundThreeLeagueRoutes.Find(id);
            if (roundThreeLeagueRoute == null)
            {
                return HttpNotFound();
            }
            return View(roundThreeLeagueRoute);
        }

        // GET: RoundThreeLeagueRoutes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoundThreeLeagueRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamName,CountryCode,Ranking")] RoundThreeLeagueRoute roundThreeLeagueRoute)
        {
            if (ModelState.IsValid)
            {
                db.RoundThreeLeagueRoutes.Add(roundThreeLeagueRoute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roundThreeLeagueRoute);
        }

        // GET: RoundThreeLeagueRoutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundThreeLeagueRoute roundThreeLeagueRoute = db.RoundThreeLeagueRoutes.Find(id);
            if (roundThreeLeagueRoute == null)
            {
                return HttpNotFound();
            }
            return View(roundThreeLeagueRoute);
        }

        // POST: RoundThreeLeagueRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamName,CountryCode,Ranking")] RoundThreeLeagueRoute roundThreeLeagueRoute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roundThreeLeagueRoute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roundThreeLeagueRoute);
        }

        // GET: RoundThreeLeagueRoutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundThreeLeagueRoute roundThreeLeagueRoute = db.RoundThreeLeagueRoutes.Find(id);
            if (roundThreeLeagueRoute == null)
            {
                return HttpNotFound();
            }
            return View(roundThreeLeagueRoute);
        }

        // POST: RoundThreeLeagueRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoundThreeLeagueRoute roundThreeLeagueRoute = db.RoundThreeLeagueRoutes.Find(id);
            db.RoundThreeLeagueRoutes.Remove(roundThreeLeagueRoute);
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
