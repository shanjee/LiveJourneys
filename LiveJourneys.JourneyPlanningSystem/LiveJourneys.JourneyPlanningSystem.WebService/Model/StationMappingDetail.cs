using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LiveJourneys.JourneyPlanningSystem.WebService.Model
{
    [DataContract]
    public class StationMappingDetail
    {
        public StationMappingDetail()
        { }

        public StationMappingDetail(StationMapping mappig)
        {
            this.FromStaionId = mappig.FromStaionId;
            this.ToStationId = mappig.ToStationId;
            this.LineId = mappig.LineId;
            this.Distance = mappig.Distance;
            this.IsDeleay = mappig.IsDeleay;
            this.FromStationsName = mappig.FromStation.Name;
            this.ToStationsName = mappig.ToStation.Name;
            this.LineName = mappig.Line.Name;
        }

        [DataMember]
        public int FromStaionId { get; set; }
        [DataMember]
        public int ToStationId { get; set; }
        [DataMember]
        public string FromStationsName { get; set; }
        [DataMember]
        public string ToStationsName { get; set; }
        [DataMember]
        public int LineId { get; set; }
        [DataMember]
        public string LineName { get; set; }
        [DataMember]
        public double Distance { get; set; }
        [DataMember]
        public bool? IsDeleay { get; set; }
    }
}