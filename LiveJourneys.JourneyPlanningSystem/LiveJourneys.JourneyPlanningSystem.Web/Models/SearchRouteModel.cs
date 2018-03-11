using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveJourneys.JourneyPlanningSystem.Web.Models
{
    public class SearchRouteModel
    {
        [Display(Name ="From Station")]
        public string SelectedFromStationsId { get; set; }
        [Display(Name = "To Station")]
        public string SelectedToStationsId { get; set; }
        public List<SelectListItem> Stations { get; set; }
    }
}