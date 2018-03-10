using LiveJourneys.JourneyPlanningSystem.Data;
using LiveJourneys.JourneyPlanningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Service.Business
{
    public class RouteManager
    {
        private DijkstraAlgorithm _algorithm;

        public List<int> DistinctStationIds { get; set; }

        static JourneyPlanningSystemDbContext context = new JourneyPlanningSystemDbContext();
        BasicEFRepository<StationMapping> basicEFRepository = new BasicEFRepository<StationMapping>(context);
        BasicEFRepository<Station> stationContext = new BasicEFRepository<Station>(context);

        #region Public function
        public RouteManager()
        {
            _algorithm = new DijkstraAlgorithm();
        }
        public List<Station> FindPath(int sourceNode, int destinationNode)
        {
            //var graph = new double[,]
            //{
            //    // 0   1   2   3   4   5  
            //    { 0,  1.4,  0,  0,  6,7.4 }, // 0
            //    { 0,0,1,0,4.4,0 }, // 1
            //    { 0,0,0,1,2,0 }, // 2
            //    { 0,0,0,0,0,0 }, // 3
            //    { 0,0,0,2.5,0,3 }, // 4
            //    { 0,0,2,0,0,0}, // 5
            //};
            var dataList = basicEFRepository.GetAll().ToList();
            var distinctStationIds = GetDistinctStaionIds(dataList);
            var graph = GetGraphData(dataList,distinctStationIds);
            var tempStationIds = _algorithm.FindPath(graph, distinctStationIds.ToList().IndexOf(sourceNode), distinctStationIds.ToList().IndexOf(destinationNode));

            List<Station> listOfStations = new List<Station>();

            foreach (int item in tempStationIds)
            {
                listOfStations.Add(stationContext.GetById(distinctStationIds[item]).Result);
            }
            

            return listOfStations;
        }

        public List<Station> GetAllStations()
        {
            var stations = stationContext.GetAll().ToList();

            return stations;
        }

        public double GetDistance(List<Station> stations)
        {
            double distance = 0;

            for (int i = 0; i < stations.Count; i++)
            {
                if (i < stations.Count - 1)
                {
                    var currentStation = stations[i];
                    var nextStation = stations[i+1];

                    distance = distance + currentStation.StationMappings.Where(x => (x.FromStaionId == currentStation.Id && x.ToStationId == nextStation.Id)).First().Distance;
                }

            }

            return distance;
        }
        #endregion


        #region Private Regions

        private int [] GetDistinctStaionIds(List<StationMapping> dataList)
        {
           
         
            var fromStationIdArray = dataList.OrderBy(f => f.FromStaionId).Select(a => a.FromStaionId).ToList();
            var toStationIdArray = dataList.OrderBy(f => f.ToStationId).Select(a => a.ToStationId).ToList();
            var distinctStationIds = fromStationIdArray.Concat(toStationIdArray).Distinct().ToList();

            distinctStationIds.Sort();

            return distinctStationIds.ToArray();
        }

        private new double[,] GetGraphData(List<StationMapping> dataList,int [] distinctStationIds)
        {
            
            var arraySize = distinctStationIds.Count();

            //define the multi array
            double[,] graphArray = new double[arraySize, arraySize];

            // Insert default data and consturuct the stations in to dimention

            foreach (var station in dataList)
            {
                graphArray[distinctStationIds.ToList().IndexOf(station.FromStaionId), distinctStationIds.ToList().IndexOf(station.ToStationId)] = station.Distance;
            }

            return graphArray;
        }

        #endregion
    }
}
