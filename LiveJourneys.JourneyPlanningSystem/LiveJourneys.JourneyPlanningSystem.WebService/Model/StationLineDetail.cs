using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LiveJourneys.JourneyPlanningSystem.WebService.Model
{
    [DataContract]
    public class StationLineDetail
    {
        public StationLineDetail()
        { }

        public StationLineDetail(StationLine line)
        {
            this.Id = line.Id;
            this.LineId = line.LineId;
            this.StationId = line.StationId;
            this.OrderNumber = line.OrderNumber;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int LineId { get; set; }

        [DataMember]
        public int StationId { get; set; }
        [DataMember]
        public int OrderNumber { get; set; }
    }
}