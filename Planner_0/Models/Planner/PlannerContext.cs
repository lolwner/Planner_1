using System.Collections.Generic;
using System.Data.Entity;

namespace Planner_0.Models.Planner {

    //DB model as context
    public class PlannerContext : DbContext {
        public DbSet<PlannerModel.Category> Category { get; set; }
        public DbSet<PlannerModel.Task> Task { get; set; }
    }
}