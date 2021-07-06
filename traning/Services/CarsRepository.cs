using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Authentication;
using traning.DTOs.Responces;
using traning.Entities;

namespace traning.Services
{
    public class CarsRepository
    {
        private string _getCarSql = @"
            select c.Id,
                   Mileage,
                   Year,
                   Price,
                   m.Id,
                   M.Name ModelName,
                   B.Name BrandName,
                   B2.Name BodyName,
                   L.Id,
                   Location LocationName
            from Cars c
                   join Model m on c.ModelId = m.Id
                   join Location L on c.LocationId = L.Id
                   join Brand B on m.BrandId = B.Id
                   join Body B2 on B2.Id = m.BodyId
            where c.Id = @carId
            ";
        
        private string _getAllCarsSql = @"
            select m.Name     ModelName,
                   b.Name     BrandName,
                   c.Mileage,
                   c.Year,
                   c.Price,
                   l.Location LocationName,
                   bo.Name    BodyName
            from Cars c
                     join Model m on c.ModelId = m.Id
                     join Brand b on m.BrandId = b.Id
                     join Body bo on m.BodyId = bo.Id
                     join Location l on c.LocationId = l.Id
            ";
        
        
        private readonly string _connectionString;
        private string _insertCarSql = @"
            insert into Cars(LocationId, ModelId, Year, Price, Mileage) 
            values(@locationId, @modelId, @year, @price, @mileage)
        ";
         
        public CarsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<CarDto> GetAllCars()
        {
            
            using IDbConnection connection = new SqlConnection(_connectionString);
            IEnumerable<CarDto> cars = connection.Query<CarDto>(_getAllCarsSql);
            return cars; 
        }

        public void AddCar(Car car) 
        {
            
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Execute(_insertCarSql,
                new
                {
                    modelId = car.ModelId,
                    locationId = car.LocationId,
                    year = car.Year,
                    price = car.Price,
                    mileage = car.Mileage,
                });

        }
        
        public Car2Dto GetCar(int carId)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            var car = connection.Query<CarDetailsDto, CarModelDto, CarLocationDto, Car2Dto>(_getCarSql,
                (details, model, location) => new Car2Dto
                {
                        
                    Mileage = details.Mileage,
                    Price = details.Price,
                    Year = details.Year,
                    Model = new Model2Dto
                    {
                        Name = model.ModelName,
                        Body = new Body2Dto
                        {
                            Name = model.BodyName,
                        },
                        Brand = new Brand2Dto
                        {
                            Name = model.BrandName,
                        }
                    },
                    Location = new Location2Dto
                    {
                        Name = location.LocationName,
                    },
                },new {carId});
            return car.First(); 
        }
    }
}