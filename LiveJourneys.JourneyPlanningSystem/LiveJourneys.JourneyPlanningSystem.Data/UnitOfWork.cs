using LiveJourneys.JourneyPlanningSystem.Models;
using LiveJourneys.JourneyPlanningSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private JourneyPlanningSystemDbContext context = new JourneyPlanningSystemDbContext();

        public IBasicRepository<User> Users { get; private set; }
        public IBasicRepository<UserType> UserTypes { get; private set; }
        public IBasicRepository<Line> TrainLines { get; private set; }
        public IBasicRepository<Station> Stations { get; private set; }
        public IBasicRepository<StationMapping> StationMappings { get; private set; }

        public UnitOfWork()
        {
            Users = new BasicRepository<User>(context);
            UserTypes = new BasicRepository<UserType>(context);
            TrainLines = new BasicRepository<Line>(context);
            Stations = new BasicRepository<Station>(context);
            StationMappings = new BasicRepository<StationMapping>(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
