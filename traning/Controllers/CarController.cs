using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using traning.Entities;
using traning.Services;

namespace traning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private CarsRepository _carsRepository;

        public CarController(CarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cars = _carsRepository.GetAllCars();
            return Ok(cars);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Car car)
        {
            _carsRepository.AddCar(car);
            return Ok();
        }
        
        [HttpGet("{carId}")]
        public IActionResult Get(int carId)
        {
            var car = _carsRepository.GetCar(carId);
            return Ok(car);
        }
    }
}