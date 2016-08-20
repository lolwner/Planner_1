using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;

namespace Planner_0.Models.Planner {
    
    public class PlannerModel {

        public static PlannerContext DB = new PlannerContext();

        //Representation of each class as database column
        public class Category {
            [Key]
            public int Category_ID { get; set; }

            [Required]
            public string User_ID { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            public Category() {
                this.Name = " ";
                this.User_ID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            }

            public Category(string name) {
                this.Name = name;
                this.User_ID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            }

        }
 
        public class Task {
            [Key]
            public int Task_ID { get; set; }

            [Required]
            public string User_ID { get; set; }

            [Required]
            [StringLength(100)]
            public string Title { get; set; }
            
            [Required]
            public DateTime Creation_Time { get; set; }

            [Required]
            public int Category_ID { get; set; }
            
            [Required]
            public DateTime Deadline { get; set; }

            //Default constructors, id search using context
            public Task() {
                this.Title = " ";
                this.Creation_Time = new DateTime(2000, 1, 1);
                this.Deadline = new DateTime(2001, 1, 1);
                this.User_ID = System.Web.HttpContext.Current.User.Identity.GetUserId();
            }

            public Task(string task) {
                this.Title = task;
                this.Creation_Time = new DateTime(2000, 1, 1);
                this.Deadline = new DateTime(2001, 1, 1);
                this.User_ID = System.Web.HttpContext.Current.User.Identity.GetUserId();
                this.Category_ID = 0;
            }

            public Category Get_category() {
                try {
                    return DB.Category.Find(this.Category_ID);
                }
                catch {
                    return null;
                }
            }

        }
    }
}