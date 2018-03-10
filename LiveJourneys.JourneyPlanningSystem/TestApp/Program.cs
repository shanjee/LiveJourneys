using LiveJourneys.JourneyPlanningSystem.Data;
using LiveJourneys.JourneyPlanningSystem.Models;
using LiveJourneys.JourneyPlanningSystem.Service.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RouteManager routemanager = new RouteManager();
            var returndata = routemanager.FindPath(1, 3);

            Console.ReadLine();
            //GetGraphArray();
        }

        private static  void GetGraphArray()
        {
            var dataList = new UnitOfWork().StationMappings.Get().ToList();  

            var distinctCategories = dataList.Select(m => new { m.FromStaionId, m.ToStationId }).Distinct().Count();

            var fromStationIdArray = dataList.OrderBy(f => f.FromStaionId).Select(a => a.FromStaionId).ToList();
            var toStationIdArray = dataList.OrderBy(f => f.ToStationId).Select(a => a.ToStationId).ToList();

            var concatArray = fromStationIdArray.Concat(toStationIdArray).Distinct().ToList();

            concatArray.Sort();

            var arraySize = concatArray.Count();

            //define the multi array
            double[,] graphArray = new double[arraySize, arraySize];

            var indexOfFrom = fromStationIdArray.IndexOf(5);

            // Insert default data and consturuct the stations in to dimention

            foreach (var station in dataList)
            {
                graphArray[concatArray.IndexOf(station.FromStaionId), concatArray.IndexOf(station.ToStationId)] = station.Distance;
            }

           

            Console.ReadKey();

        }
    }
}
