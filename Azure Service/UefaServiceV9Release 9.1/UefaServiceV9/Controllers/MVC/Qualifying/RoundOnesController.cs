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
            return View(db.RoundOnes.OrderByDescending(one => one.Ranking));
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

      


        // GET: RoundOnes/Edit/5
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
        public ActionResult Edit([Bind(Include = "Id,TeamName,CountryCode,Ranking")] RoundOne roundOne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roundOne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roundOne);
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
