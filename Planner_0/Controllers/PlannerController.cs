using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planner_0.Models.Planner;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Net;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Planner_0.Controllers
{
    public class PlannerController : Controller
    {
        private static PlannerContext DB = new PlannerContext();
        //var user = UserManager.FindById(User.Identity.GetUserId());

        public static string User_Id = System.Web.HttpContext.Current.User.Identity.GetUserId();


        public ActionResult StartPageView()
        {
            return View();
        }

        [Authorize]
        public ActionResult TaskView()
        {
            return View();
        }

        [Authorize]
        public ActionResult ListOfTaskView()
        {
            ViewBag.User = System.Web.HttpContext.Current.User.Identity.GetUserId();

            IEnumerable<PlannerModel.Task> tasks = DB.Task;
            ViewBag.Task = tasks.Where(t => t.User_ID == System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, User_ID, Creation_Time, Category_ID, Deadline")]PlannerModel.Task task)
        {
            task.User_ID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            try
            {
                if (ModelState.IsValid)
                {
                    DB.Task.Add(task);
                    DB.SaveChanges();
                    return RedirectToAction("ListOfTaskView");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(task);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlannerModel.Task task = DB.Task.Find(id);
            ViewBag.Time = DateTime.Now;
            

            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                PlannerModel.Task task = DB.Task.Find(id);
                DB.Task.Remove(task);
                DB.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("ListOfTaskView");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlannerModel.Task task = DB.Task.Find(id);
            //task.User_ID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var taskToUpdate = DB.Task.Find(id);
            taskToUpdate.User_ID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (TryUpdateModel(taskToUpdate, "",
               new string[] { "Title", "Category_ID", "Deadline" }))
            {
                try
                {
                    DB.SaveChanges();

                    return RedirectToAction("ListOfTaskView");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(taskToUpdate);
        }

        public JsonResult GetTasks()
        {
            IEnumerable<PlannerModel.Task> tasks = DB.Task;
            var JsonTasks = tasks
                .Where(t => t.User_ID == System.Web.HttpContext.Current.User.Identity.GetUserId())
                .ToList();
            return Json(JsonTasks, JsonRequestBehavior.AllowGet);  
        }
    }



}
