using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using traning.Entities;
using traning.Services;

namespace traning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelController : ControllerBase
    {
        private ModelRepository _modelRepository;

        public ModelController(ModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _modelRepository.GetModel();
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Model model)
        {
            _modelRepository.AddModel(model);
            return Ok();
        }
    }
}