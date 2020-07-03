using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using CTeleport.GeoDistanceResolver.Application;
using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure;
using CTeleport.GeoDistanceResolver.Data.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CTeleport.GeoDistanceResolver.Web.Controllers
{
    [Route("[controller]"), ApiVersion("1.0")]
    [ApiController, Produces(MediaTypeNames.Application.Json)]
    public class GeoCoordinateResolverController: ControllerBase
    {
        private readonly ILogger<GeoCoordinateResolverController> _logger;
        private readonly GeoCoordinateService _geoCoordinateService;

        public GeoCoordinateResolverController(ILogger<GeoCoordinateResolverController> logger,
            GeoCoordinateService geoCoordinateService)
        {
            _logger = logger;
            _geoCoordinateService = geoCoordinateService;
        }

        [HttpGet]
        public IActionResult GetDistance(
            [FromQuery] string airportFrom,
            [FromQuery] string airportTo,
            [FromQuery] EMeasureUnitDto measureUnit = EMeasureUnitDto.Meters)
        {
            var result = _geoCoordinateService.FindDistanceBetweenAirports(airportFrom, airportTo, measureUnit);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
