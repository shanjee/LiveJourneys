using LiveJourneys.JourneyPlanningSystem.Web.JourneyPlanningSystemService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LiveJourneys.JourneyPlanningSystem.Web.Models
{
    public class SearchResultModel
    {
        [Display(Name = "From Station")]
        public string SelectedFromStationsId { get; set; }
        [Display(Name = "To Station")]
        public string SelectedToStationsId { get; set; }


        public string SelectedFromStationsName { get; set; }
        public string SelectedToStationsName { get; set; }

        public StationRouteInfo RouteInfo { get; set; }
    }
}