using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planner_0.Models.Planner;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Net;

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
        public ActionResult TaskView() {
            return View();
        }

        [Authorize]
        public ActionResult ListOfTaskView() {
            ViewBag.User = System.Web.HttpContext.Current.User.Identity.GetUserId();

            IEnumerable<PlannerModel.Task> tasks = DB.Task;
            ViewBag.Task = tasks.Where(t => t.User_ID == System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlannerModel.Task task = DB.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

    }
}