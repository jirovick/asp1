using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using traning.Entities;
using traning.Services;

namespace traning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private LocationRepository _locationRepository;

        public LocationController(LocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Location> location = _locationRepository.GetLocation();
            return Ok(location);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Location location)
        {
            _locationRepository.AddLocation(location);
            return Ok();
        }
    }
}