using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner_0.Controllers.PlannerControlers
{
    public class TaskController : Controller
    {
        [Authorize]
        public ActionResult Task()
        {
            return View();
        }
    }
}