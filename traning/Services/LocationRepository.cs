using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Authentication;
using traning.Entities;

namespace traning.Services
{
    public class LocationRepository
    {
        private readonly string _connectionString;

        public LocationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Location> GetLocation()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            IEnumerable<Location> location = connection.Query<Location>("select Id, Location from Location");
            return location; 
        }

        public void AddLocation(Location location) 
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Execute("insert into Location(Id, location) values(@location, @id)",
                new
                {
                    location = location.Name,
                });

        }
    }
}