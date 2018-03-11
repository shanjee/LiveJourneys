using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LiveJourneys.JourneyPlanningSystem.WebService.Model
{
    [DataContract]
    public class StationDetail
    {
        public StationDetail()
        { }

        public StationDetail(Station station)
        {
            this.Id = station.Id;
            this.Name = station.Name;

            StationLineDetails = new List<StationLineDetail>();
            foreach (var item in station.StationLines)
            {
                StationLineDetails.Add(new StationLineDetail(item));
            }

            IsConnectingStaion = StationLineDetails.Count > 0 ? true : false;

            StationMappingDetails = new List<StationMappingDetail>();
            foreach (var item in station.FromStationMappings)
            {
                StationMappingDetails.Add(new StationMappingDetail(item));
            }
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool IsConnectingStaion { get; set; }

        [DataMember]
        public virtual ICollection<StationLineDetail> StationLineDetails { get; set; }

        [DataMember]
        public virtual ICollection<StationMappingDetail> StationMappingDetails { get; set; }
    }
}