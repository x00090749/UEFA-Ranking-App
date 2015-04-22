using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.MVC.Country_Rankings
{
    public class CountryRankingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CountryRankings
        public ActionResult Index()
        {
            return View(db.CountryRankings.ToList());
        }

        // GET: CountryRankings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryRanking countryRanking = db.CountryRankings.Find(id);
            if (countryRanking == null)
            {
                return HttpNotFound();
            }
            return View(countryRanking);
        }

        // GET: CountryRankings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryRankings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CountryName,Ranking")] CountryRanking countryRanking)
        {
            if (ModelState.IsValid)
            {
                db.CountryRankings.Add(countryRanking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countryRanking);
        }

        // GET: CountryRankings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryRanking countryRanking = db.CountryRankings.Find(id);
            if (countryRanking == null)
            {
                return HttpNotFound();
            }
            return View(countryRanking);
        }

        // POST: CountryRankings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CountryName,Ranking")] CountryRanking countryRanking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryRanking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryRanking);
        }

        // GET: CountryRankings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryRanking countryRanking = db.CountryRankings.Find(id);
            if (countryRanking == null)
            {
                return HttpNotFound();
            }
            return View(countryRanking);
        }

        // POST: CountryRankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryRanking countryRanking = db.CountryRankings.Find(id);
            db.CountryRankings.Remove(countryRanking);
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
