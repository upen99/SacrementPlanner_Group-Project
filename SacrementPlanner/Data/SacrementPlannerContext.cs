using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacrementPlanner.Models;

namespace SacrementPlanner.Data
{
    public class SacrementPlannerContext : DbContext
    {
        public SacrementPlannerContext (DbContextOptions<SacrementPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<SacrementPlanner.Models.Members> Members { get; set; }

        public DbSet<SacrementPlanner.Models.SacrementMeetings> SacrementMeetings { get; set; }
    }
}
