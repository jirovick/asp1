using traning.Entities;

namespace traning.DTOs.Responces
{
    public class Car2Dto
    {
        public double Mileage { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public Model2Dto Model { get; set; }
        public Location2Dto Location { get; set; }
    }

    public class Model2Dto
    {
        public Body2Dto Body { get; set; }
        public string Name { get; set; }
        public Brand2Dto Brand { get; set; }
        
    }

    public class Brand2Dto
    {
        public string Name { get; set; }
    }

    public class Body2Dto
    {
        public string Name { get; set; }
    }

    public class Location2Dto
    {
        public string Name { get; set; }
    }
}