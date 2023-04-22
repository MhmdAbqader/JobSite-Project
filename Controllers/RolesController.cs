using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace trial2.Controllers
{
    [Authorize(Roles ="admin")]
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
             
            return View(db.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            var role = db.Roles.Find(id);
            if (role != null)
            {
                return View(role);
            }
            else
            {
                return HttpNotFound();
            }
          
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
             
                // TODO: Add insert logic here
                if (ModelState.IsValid) {
                    db.Roles.Add(role);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                else
                return View(role);
             
             
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var role = db.Roles.Find(id);
            if (role != null)
            {
                return View(role);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);     
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            var role = db.Roles.Find(id);
            if (role != null)
            {
                return View(role);
            }
            else
            {
                return HttpNotFound();
            }

        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole r)
        {
            var myrole = db.Roles.Find(r.Id);
            db.Roles.Remove(myrole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
