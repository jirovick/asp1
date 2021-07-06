using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using traning.Entities;
using traning.Services;

namespace traning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyController : ControllerBase
    {
        private BodyRepository _bodyRepository;

        public BodyController(BodyRepository bodyRepository)
        {
            _bodyRepository = bodyRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Body> body = _bodyRepository.GetBody();
            return Ok(body);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Body body)
        {
            _bodyRepository.AddBody(body);
            return Ok();
        }
    }
}