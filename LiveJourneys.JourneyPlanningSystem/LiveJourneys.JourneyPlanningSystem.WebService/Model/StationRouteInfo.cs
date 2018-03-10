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
        private List<Station> path;

        public StationRouteInfo()
        {            
        }

        public StationRouteInfo(List<Station> path)
        {
            this.path = path;
            Distance = 4.4;
            Name = "ajith";
            StationId = path.First();
        }

        [DataMember]
        public double Distance { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<StationDetail> Stations { get; set; }
    }
}