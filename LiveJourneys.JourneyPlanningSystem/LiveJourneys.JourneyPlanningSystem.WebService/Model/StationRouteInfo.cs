using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using LiveJourneys.JourneyPlanningSystem.Models;

namespace LiveJourneys.JourneyPlanningSystem.WebService.Model
{
    [DataContract]
    public class StationRouteInfo
    {
        public StationRouteInfo()
        {            
        }
        
        public StationRouteInfo(List<Station> path)
        {
            Stations = new List<StationDetail>();
            foreach (var item in path)
            {
                Stations.Add(new StationDetail(item));
            }
        }

        [DataMember]
        public double Distance { get; set; }
        [DataMember]
        public ICollection<StationDetail> Stations { get; set; }
    }
}