using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using traning.DTOs.Responces;
using traning.Entities;

namespace traning.Services
{
    public class BrandRepository
    {
        private string _getBrands = @"
            select b.Name,  
                   (select count(m.Id) 
                   from Model m where b.Id = m.BrandId ) 
                       ModelCount,      
                       b.IsLuxury 
                   from Brand b
            ";
        
        private readonly string _connectionString;
        public BrandRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public IEnumerable<BrandDto> GetBrand()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            IEnumerable<BrandDto> brand = connection.Query<BrandDto>(_getBrands);
            return brand; 
        }
        
        public void AddBrand(Brand brand) 
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Execute("insert into Brand(Id, Name, IsLuxury) values(@id, @name, @isLuxury)",
                new
                {
                    name = brand.Name,
                    isluxury = brand.IsLuxury,
                });

        }
    }
}