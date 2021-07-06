using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using traning.Entities;
using traning.Services;

namespace traning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private BrandRepository _brandRepository;

        public BrandController(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var brand = _brandRepository.GetBrand();
            return Ok(brand);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Brand brand)
        {
            _brandRepository.AddBrand(brand);
            return Ok();
        }
    }
}