using ApiRutas.Models;
using ApiRutas.service;

namespace ApiRutas.Tests
{
    public class ShortestPathServiceTests
    {
        [Fact]
        public void GetOptimalRoute_ShouldReturnCorrectRoute()
        {
            var roads = new List<Road>
        {
            new Road { From = "A", To = "B", Time = 10 },
            new Road { From = "B", To = "C", Time = 15 },
            new Road { From = "A", To = "C", Time = 30 },
            new Road { From = "C", To = "D", Time = 5 },
            new Road { From = "B", To = "D", Time = 25 }
        };

            var request = new RouteRequest
            {
                Cities = new List<string> { "A", "B", "C", "D" },
                Roads = roads,
                Origin = "A",
                Destination = "D"
            };

            var service = new ShortestPathService();
            var response = service.GetOptimalRoute(request);

            Assert.Equal(new List<string> { "A", "B", "C", "D" }, response.Route);
            Assert.Equal(30, response.TotalTime);
        }
    }

}