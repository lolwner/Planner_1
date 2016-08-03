using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planner_0.Models.Planner;

namespace Planner_0.Controllers.PlannerControlers
{
    public class CategoryController : Controller
    {
        public ActionResult Category(PlannerModel.Category category, string action = "empty")
        {
            switch (action) {
                case "create":
                    ModelState.Clear();
                    ViewBag.action = action;

                    break;
                case "add":

                    break;

            }
            return View();
        }
    }
}