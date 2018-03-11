using LiveJourneys.JourneyPlanningSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Models
{
    public interface IUnitOfWork:IDisposable
    {
        IBasicRepository<User> Users { get; }
        IBasicRepository<UserType> UserTypes { get; }
        IBasicRepository<Line> TrainLines { get; }
        IBasicRepository<Station> Stations { get; }
        IBasicRepository<StationLine> StationLines { get; }
        IBasicRepository<StationMapping> StationMappings { get; }

        int Complete();
    }
}
