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


            RouteMappingDetails = new List<StationMappingDetail>();

            foreach (var item in path)
            {
                Stations.Add(new StationDetail(item));

                var nextIndex = path.IndexOf(item) + 1;
                if(nextIndex < path.Count)
                {
                    var nextStation = path[nextIndex];
                    var mapping = item.FromStationMappings.Where(x=>(x.FromStaionId == item.Id && x.ToStationId == nextStation.Id)).FirstOrDefault();
                    RouteMappingDetails.Add(new StationMappingDetail(mapping));
                }
            }

            IsSingleLineRoute = RouteMappingDetails.Select(x => x.LineId).Distinct().Count() > 1 ? true : false;
        }

        [DataMember]
        public double Distance { get; set; }
        [DataMember]
        public bool IsSingleLineRoute { get; set; }
        [DataMember]
        public ICollection<StationDetail> Stations { get; set; }
        [DataMember]
        public virtual ICollection<StationMappingDetail> RouteMappingDetails { get; set; }
    }
}