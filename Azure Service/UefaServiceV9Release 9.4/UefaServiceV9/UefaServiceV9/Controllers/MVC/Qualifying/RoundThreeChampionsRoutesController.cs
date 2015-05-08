﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.MVC.Qualifying
{
    public class RoundThreeChampionsRoutesController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: RoundThreeChampionsRoutes
        public ActionResult Index()
        {
            return View(_db.RoundThreeChampionsRoutes.OrderByDescending(one => one.Ranking));
        }

        // GET: RoundThreeChampionsRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundThreeChampionsRoute roundThreeChampionsRoute = _db.RoundThreeChampionsRoutes.Find(id);
            if (roundThreeChampionsRoute == null)
            {
                return HttpNotFound();
            }
            return View(roundThreeChampionsRoute);
        }

        // GET: RoundThreeChampionsRoutes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoundThreeChampionsRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamName,CountryCode,Ranking")] RoundThreeChampionsRoute roundThreeChampionsRoute)
        {
            if (ModelState.IsValid)
            {
                _db.RoundThreeChampionsRoutes.Add(roundThreeChampionsRoute);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roundThreeChampionsRoute);
        }

        // GET: RoundThreeChampionsRoutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundThreeChampionsRoute roundThreeChampionsRoute = _db.RoundThreeChampionsRoutes.Find(id);
            if (roundThreeChampionsRoute == null)
            {
                return HttpNotFound();
            }
            return View(roundThreeChampionsRoute);
        }

        // POST: RoundThreeChampionsRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamName,CountryCode,Ranking")] RoundThreeChampionsRoute roundThreeChampionsRoute)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(roundThreeChampionsRoute).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roundThreeChampionsRoute);
        }

        // GET: RoundThreeChampionsRoutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundThreeChampionsRoute roundThreeChampionsRoute = _db.RoundThreeChampionsRoutes.Find(id);
            if (roundThreeChampionsRoute == null)
            {
                return HttpNotFound();
            }
            return View(roundThreeChampionsRoute);
        }

        // POST: RoundThreeChampionsRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoundThreeChampionsRoute roundThreeChampionsRoute = _db.RoundThreeChampionsRoutes.Find(id);
            _db.RoundThreeChampionsRoutes.Remove(roundThreeChampionsRoute);
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
