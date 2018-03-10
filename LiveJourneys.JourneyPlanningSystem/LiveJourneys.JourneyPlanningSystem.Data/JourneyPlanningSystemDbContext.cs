using LiveJourneys.JourneyPlanningSystem.Models;
using System.Data.Entity;

namespace LiveJourneys.JourneyPlanningSystem.Data
{
    public class JourneyPlanningSystemDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public JourneyPlanningSystemDbContext():base("name=LiveJourneyConnection")
        {

        }

        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<StationLine> StationLines { get; set; }
        public virtual DbSet<StationMapping> StationMappings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Line>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Line>()
                .HasMany(e => e.StationLines)
                .WithRequired(e => e.Line)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Line>()
                .HasMany(e => e.StationMappings)
                .WithRequired(e => e.Line)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.StationLines)
                .WithRequired(e => e.Station)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.StationMappings)
                .WithRequired(e => e.FromStation)
                .HasForeignKey(e => e.FromStaionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.StationMappings1)
                .WithRequired(e => e.ToStation)
                .HasForeignKey(e => e.ToStationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);
        }
    }
}