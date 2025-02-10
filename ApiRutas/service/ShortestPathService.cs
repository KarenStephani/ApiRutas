using ApiRutas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ApiRutas.service
{
    public class ShortestPathService
    {
        public RouteResponse GetOptimalRoute(RouteRequest request)
        {
            var graph = BuildGraph(request.Roads);
            var result = Dijkstra(graph, request.Origin, request.Destination);
            return new RouteResponse
            {
                Route = result.Route,
                TotalTime = result.TotalTime
            };
        }

        private Dictionary<string, List<(string, int)>> BuildGraph(List<Road> roads)
        {
            var graph = new Dictionary<string, List<(string, int)>>();

            foreach (var road in roads)
            {
                if (!graph.ContainsKey(road.From)) graph[road.From] = new List<(string, int)>();
                graph[road.From].Add((road.To, road.Time));

                // Asumiendo que las carreteras son bidireccionales
                if (!graph.ContainsKey(road.To)) graph[road.To] = new List<(string, int)>();
                graph[road.To].Add((road.From, road.Time));
            }

            return graph;
        }

        private (List<string> Route, int TotalTime) Dijkstra(Dictionary<string, List<(string, int)>> graph, string origin, string destination)
        {
            var distances = graph.Keys.ToDictionary(city => city, city => int.MaxValue);
            var previous = new Dictionary<string, string>();
            var priorityQueue = new SortedSet<(int, string)>(Comparer<(int, string)>.Create((x, y) => x.Item1 == y.Item1 ? string.Compare(x.Item2, y.Item2) : x.Item1.CompareTo(y.Item1)));

            distances[origin] = 0;
            priorityQueue.Add((0, origin));

            while (priorityQueue.Any())
            {
                var (currentDist, currentCity) = priorityQueue.Min;
                priorityQueue.Remove(priorityQueue.Min);

                if (currentCity == destination)
                    break;

                foreach (var (neighbor, time) in graph[currentCity])
                {
                    var newDist = currentDist + time;
                    if (newDist < distances[neighbor])
                    {
                        distances[neighbor] = newDist;
                        previous[neighbor] = currentCity;
                        priorityQueue.Add((newDist, neighbor));
                    }
                }
            }

            var route = new List<string>();
            var current = destination;
            while (current != null)
            {
                route.Insert(0, current);
                previous.TryGetValue(current, out current);
            }

            return (route, distances[destination]);
        }
    }
}
