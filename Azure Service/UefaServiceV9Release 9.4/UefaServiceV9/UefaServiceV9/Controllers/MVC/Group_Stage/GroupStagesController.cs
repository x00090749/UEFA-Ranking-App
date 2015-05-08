using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UefaServiceV9.Models;

namespace UefaServiceV9.Controllers.MVC.Group_Stage
{
    public class GroupStagesController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: GroupStages
        public ActionResult Index()
        {
            return View(_db.GroupStages.OrderByDescending(one => one.Ranking));
        }

        // GET: GroupStages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupStage groupStage = _db.GroupStages.Find(id);
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
        public ActionResult Create([Bind(Include = "Id,TeamName,CountryCode,Ranking")] GroupStage groupStage)
        {
            if (ModelState.IsValid)
            {
                _db.GroupStages.Add(groupStage);
                _db.SaveChanges();
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
            GroupStage groupStage = _db.GroupStages.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,TeamName,CountryCode,Ranking")] GroupStage groupStage)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(groupStage).State = EntityState.Modified;
                _db.SaveChanges();
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
            GroupStage groupStage = _db.GroupStages.Find(id);
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
            GroupStage groupStage = _db.GroupStages.Find(id);
            _db.GroupStages.Remove(groupStage);
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
