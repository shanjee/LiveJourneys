using LiveJourneys.JourneyPlanningSystem.Web.JourneyPlanningSystemService;
using LiveJourneys.JourneyPlanningSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveJourneys.JourneyPlanningSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        JourneyPlanningSystemService.JourneyPlanningSystemClient client = new JourneyPlanningSystemService.JourneyPlanningSystemClient();

        [HttpGet]
        public ActionResult Index()
        {
            

            

            //var path = client.GetRouteInformation(1, 3);


            var model = new SearchRouteModel();
            model.Stations = GetStationList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchRouteModel model)
        {
            if(!ModelState.IsValid)
            {
                model.Stations = GetStationList();
                return View(model);
            }

            var searchResult = new SearchResultModel();
            searchResult.SelectedFromStationsId = model.SelectedFromStationsId;
            searchResult.SelectedToStationsId = model.SelectedToStationsId;
            var path = client.GetRouteInformation(int.Parse(model.SelectedFromStationsId), int.Parse(model.SelectedToStationsId));

            searchResult.RouteInfo = path;
            return View("SearchResult", searchResult);
        }

        private List<SelectListItem> GetStationList()
        {
            var allStations = client.GetAllStations();
            var data = new List<SelectListItem>();

            foreach (var item in allStations)
            {
                data.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }

            return data;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RepresentStations()
        {
            ViewBag.Message = "Your Represent Stations page.";

            return View();
        }
    }
}