using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourneys.JourneyPlanningSystem.Service.Business
{
    public class DijkstraAlgorithm
    {
        public List<int> FindPath(double[,] graph, int sourceNode, int destinationNode)
        {
            var n = graph.GetLength(0);

            var distance = new double[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = double.MaxValue;
            }

            distance[sourceNode] = 0;

            var used = new bool[n];
            var previous = new int?[n];

            while (true)
            {
                var minDistance = double.MaxValue;
                var minNode = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!used[i] && minDistance > distance[i])
                    {
                        minDistance = distance[i];
                        minNode = i;
                    }
                }

                if (minDistance == double.MaxValue)
                {
                    break;
                }

                used[minNode] = true;

                for (int i = 0; i < n; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        var shortestToMinNode = distance[minNode];
                        var distanceToNextNode = graph[minNode, i];

                        var totalDistance = shortestToMinNode + distanceToNextNode;

                        if (totalDistance < distance[i])
                        {
                            distance[i] = totalDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == double.MaxValue)
            {
                return new List<int>();
            }

            var path = new LinkedList<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.AddFirst(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            return path.ToList();
        }

        public double GetPathDistance(double[,] graph, List<int> path)
        {
            double pathLength = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                pathLength += graph[path[i], path[i + 1]];
            }

            return pathLength;
        }
    }
}
