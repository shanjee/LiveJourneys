using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LiveJourneys.JourneyPlanningSystem.WebService.Model
{
    public class StationDetail
    {
        public StationDetail()
        { }

        public StationDetail(Station station)
        {
            this.Id = station.Id;
            this.Name = station.Name;
            //this.StationLineDetails = station.StationLines;
            //this.StationMappingDetails = station.StationMappingDetails;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public virtual ICollection<StationLineDetail> StationLineDetails { get; set; }

        [DataMember]
        public virtual ICollection<StationMappingDetail> StationMappingDetails { get; set; }
    }
}