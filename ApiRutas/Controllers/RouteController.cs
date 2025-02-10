using ApiRutas.Models;
using ApiRutas.service;
using Microsoft.AspNetCore.Mvc;

namespace ApiRutas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly ShortestPathService _shortestPathService;

        public RouteController(ShortestPathService shortestPathService)
        {
            _shortestPathService = shortestPathService;
        }

        [HttpPost("optimal-route")]
        public ActionResult<RouteResponse> GetOptimalRoute([FromBody] RouteRequest request)
        {
            var result = _shortestPathService.GetOptimalRoute(request);
            return Ok(result);
        }
    }
}
