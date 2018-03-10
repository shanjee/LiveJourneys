using LiveJourneys.JourneyPlanningSystem.WebService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LiveJourneys.JourneyPlanningSystem.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJourneyPlanningSystem" in both code and config file together.
    [ServiceContract]
    public interface IJourneyPlanningSystem
    {
        [OperationContract]
        List<StationDetail> GetAllStations();

        [OperationContract]
        StationRouteInfo GetRouteInformation(int fromStationId, int toStationId);
    
    }
}
