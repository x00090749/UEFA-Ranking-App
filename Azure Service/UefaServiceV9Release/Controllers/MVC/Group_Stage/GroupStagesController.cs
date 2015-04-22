using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.MVC.Group_Stage
{
    public class GroupStagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GroupStages
        public ActionResult Index()
        {
            return View(db.GroupStages.ToList());
        }

        // GET: GroupStages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupStage groupStage = db.GroupStages.Find(id);
            if (groupStage == null)
            {
                return HttpNotFound();
            }
            return View(groupStage);
        }

        // GET: GroupStages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupStages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamName,CountryCode,Ranking,TeamRankingId")] GroupStage groupStage)
        {
            if (ModelState.IsValid)
            {
                db.GroupStages.Add(groupStage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupStage);
        }

        // GET: GroupStages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupStage groupStage = db.GroupStages.Find(id);
            if (groupStage == null)
            {
                return HttpNotFound();
            }
            return View(groupStage);
        }

        // POST: GroupStages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamName,CountryCode,Ranking,TeamRankingId")] GroupStage groupStage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupStage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupStage);
        }

        // GET: GroupStages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupStage groupStage = db.GroupStages.Find(id);
            if (groupStage == null)
            {
                return HttpNotFound();
            }
            return View(groupStage);
        }

        // POST: GroupStages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupStage groupStage = db.GroupStages.Find(id);
            db.GroupStages.Remove(groupStage);
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
