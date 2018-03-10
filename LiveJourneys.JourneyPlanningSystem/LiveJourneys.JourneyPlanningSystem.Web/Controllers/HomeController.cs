using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveJourneys.JourneyPlanningSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client = new JourneyPlanningSystemService.JourneyPlanningSystemClient();

            var all = client.GetAllStations();

            var path = client.GetRouteInformation(1, 3);
            return View();
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