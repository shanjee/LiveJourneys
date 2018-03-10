using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LiveJourneys.JourneyPlanningSystem.WebService.Model;
using LiveJourneys.JourneyPlanningSystem.Service.Business;

namespace LiveJourneys.JourneyPlanningSystem.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JourneyPlanningSystem" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select JourneyPlanningSystem.svc or JourneyPlanningSystem.svc.cs at the Solution Explorer and start debugging.
    public class JourneyPlanningSystem : IJourneyPlanningSystem
    {
        public void DoWork()
        {
        }

        public StationRouteInfo GetRouteInformation(int fromStationId, int toStationId)
        {
            var manager = new RouteManager();

            var path = manager.FindPath(fromStationId, toStationId);

            var info = new StationRouteInfo(path);
            info.Distance = manager.GetDistance(path);

            return info;
        }
    }
}
