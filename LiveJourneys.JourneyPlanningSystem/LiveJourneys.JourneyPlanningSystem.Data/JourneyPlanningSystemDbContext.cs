using LiveJourneys.JourneyPlanningSystem.Models;
using System.Data.Entity;

namespace LiveJourneys.JourneyPlanningSystem.Data
{
    public class JourneyPlanningSystemDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public JourneyPlanningSystemDbContext():base("DefaultConnection")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}