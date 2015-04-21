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
    public class RoundTwoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoundTwoes
        public ActionResult Index()
        {
            var roundTwoes = db.RoundTwoes;//.Include(r => r.TeamRanking);
            return View(roundTwoes.ToList());
        }

        // GET: RoundTwoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundTwo roundTwo = db.RoundTwoes.Find(id);
            if (roundTwo == null)
            {
                return HttpNotFound();
            }
            return View(roundTwo);
        }

        // GET: RoundTwoes/Create
        public ActionResult Create()
        {
            ViewBag.TeamRankingId = new SelectList(db.TeamRankings, "Id", "TeamName");
            return View();
        }

        // POST: RoundTwoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamName,CountryCode,TeamRankingId")] RoundTwo roundTwo)
        {
            if (ModelState.IsValid)
            {
                db.RoundTwoes.Add(roundTwo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamRankingId = new SelectList(db.TeamRankings, "Id", "TeamName", roundTwo.TeamRankingId);
            return View(roundTwo);
        }

        // GET: RoundTwoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundTwo roundTwo = db.RoundTwoes.Find(id);
            if (roundTwo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamRankingId = new SelectList(db.TeamRankings, "Id", "TeamName", roundTwo.TeamRankingId);
            return View(roundTwo);
        }

        // POST: RoundTwoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamName,CountryCode,TeamRankingId")] RoundTwo roundTwo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roundTwo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamRankingId = new SelectList(db.TeamRankings, "Id", "TeamName", roundTwo.TeamRankingId);
            return View(roundTwo);
        }

        // GET: RoundTwoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundTwo roundTwo = db.RoundTwoes.Find(id);
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
            RoundTwo roundTwo = db.RoundTwoes.Find(id);
            db.RoundTwoes.Remove(roundTwo);
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
