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

        public RouteManager()
        {
            _algorithm = new DijkstraAlgorithm();
        }
        public List<Station> FindPath(int sourceNode, int destinationNode)
        {
            var graph = new double[,]
                        {
                // 0   1   2   3   4   5   6   7   8   9  10  11
                {0,  1.4,  0,  0,  6,7.4 }, // 0
            { 0,0,1,0,4.4,0 }, // 1
            {0,0,0,1,2,0 }, // 2
            { 0,0,0,0,0,0 }, // 3
            { 0,0,0,2.5,0,3 }, // 4
            {0,0,2,0,0,0}, // 5
        };

            _algorithm.FindPath(graph, sourceNode, destinationNode);

            return null;
        }
    }
}
