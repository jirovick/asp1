using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using traning.Entities;

namespace traning.Services
{
    public class BodyRepository
    {
        private readonly string _connectionString;

        public BodyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public IEnumerable<Body> GetBody()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            IEnumerable<Body> body = connection.Query<Body>("select Id, Name from Body");
            return body; 
        }
        
        public void AddBody(Body body) 
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Execute("insert into Body(Id, Name) values(@id, @name)",
                new
                {
                    name = body.Name,
                });

        }
    }
    
}