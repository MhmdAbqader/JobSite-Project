using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trial2.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var list = db.Cats1.ToList();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            Session["jobid"] = id; // session store id as string so i want to cast at using it
            return View(job);
        }

        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(string MSG)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["jobid"];
            ApplyForJob job = new ApplyForJob();
            // add data to apply table
            var check = db.ApplyForJobs.Where(x=>x.UserId == UserId && x.JodId == JobId).ToList();


            if (check.Count == 0 ) { 
            job.UserId = UserId;
            job.JodId = JobId;
            job.MSG = MSG;
            job.DATE = DateTime.Now;

            db.ApplyForJobs.Add(job);
            db.SaveChanges();
            ViewBag.alert = "شكرا لك لقد تمت الاضافة بنجاح";
            }
            else
            {

                ViewBag.alert = "excuse me !!";
            }
            return View();
        }

        [Authorize]
        public ActionResult Number_jobs_user()
        {
            var UserId = User.Identity.GetUserId();
            var numjobs = db.ApplyForJobs.Where(x=>x.UserId==UserId).ToList();
            ViewBag.x = numjobs.Count();
            return View(numjobs);

        }
        [Authorize]
        public ActionResult GetJobsByPublisher()
        {
            var UserID = User.Identity.GetUserId();
            var job= from apply in db.ApplyForJobs join jobbbb in db.Jobs
                     on apply.JodId equals jobbbb.Id
                     where jobbbb.User.Id == UserID
                     select apply;

            return View(job.ToList());
        }
        public ActionResult jobDetails(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult search(string SRCH)
        {
            var result = db.Jobs.Where(a => a.jobtitle.Contains(SRCH) || a.jobcontent.Contains(SRCH)
             || a.category.catname.Contains(SRCH)).ToList();
            return View(result);
        }


    }
}