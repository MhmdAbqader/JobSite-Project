using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using trial2.Models;

namespace trial2.Controllers
{
    //to prevent anyone can access views of this controller without logining
    [Authorize(Roles ="admin")]
    public class Cats1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cats1
        //allow to anyone can access this view
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Cats1.ToList());
        }

        // GET: Cats1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cats1 cats1 = db.Cats1.Find(id);
            if (cats1 == null)
            {
                return HttpNotFound();
            }
            return View(cats1);
        }

        // GET: Cats1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cats1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,catname,catdescription")] Cats1 cats1)
        {
            if (ModelState.IsValid)
            {
                db.Cats1.Add(cats1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cats1);
        }

        // GET: Cats1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cats1 cats1 = db.Cats1.Find(id);
            if (cats1 == null)
            {
                return HttpNotFound();
            }
            return View(cats1);
        }

        // POST: Cats1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,catname,catdescription")] Cats1 cats1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cats1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cats1);
        }

        // GET: Cats1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cats1 cats1 = db.Cats1.Find(id);
            if (cats1 == null)
            {
                return HttpNotFound();
            }
            return View(cats1);
        }

        // POST: Cats1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cats1 cats1 = db.Cats1.Find(id);
            db.Cats1.Remove(cats1);
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
