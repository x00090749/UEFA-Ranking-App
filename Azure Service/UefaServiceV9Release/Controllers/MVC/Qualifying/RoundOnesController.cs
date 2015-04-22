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
    public class RoundOnesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoundOnes
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.RoundOnes.ToList());
        }

        // GET: RoundOnes/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundOne roundOne = db.RoundOnes.Find(id);
            if (roundOne == null)
            {
                return HttpNotFound();
            }
            return View(roundOne);
        }

        // GET: RoundOnes/Create
         [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoundOnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "Id,TeamName,CountryCode,Ranking,TeamRankingId")] RoundOne roundOne)
        {
            if (ModelState.IsValid)
            {
                db.RoundOnes.Add(roundOne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roundOne);
        }

        // GET: RoundOnes/Edit/5
         [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundOne roundOne = db.RoundOnes.Find(id);
            if (roundOne == null)
            {
                return HttpNotFound();
            }
            return View(roundOne);
        }

        // POST: RoundOnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "Id,TeamName,CountryCode,Ranking,TeamRankingId")] RoundOne roundOne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roundOne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roundOne);
        }

        // GET: RoundOnes/Delete/5
         [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundOne roundOne = db.RoundOnes.Find(id);
            if (roundOne == null)
            {
                return HttpNotFound();
            }
            return View(roundOne);
        }

        // POST: RoundOnes/Delete/5
         [Authorize(Roles = "canEdit")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoundOne roundOne = db.RoundOnes.Find(id);
            db.RoundOnes.Remove(roundOne);
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
