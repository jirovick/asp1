using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using traning.DTOs.Responces;
using traning.Entities;

namespace traning.Services
{
    public class ModelRepository
    {
        private string _getModels = @"
            select m.color,
                   m.IsNew,
                   m.Name ModelName,
                   b.Name BrandName
            from Model m
                     join Brand b on m.BrandId = b.Id  
        ";
        
        private readonly string _connectionString;
        public ModelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public IEnumerable<ModelDto> GetModel()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            IEnumerable<ModelDto> models = connection.Query<ModelDto>(_getModels);
            return models; 
        }
        
        public void AddModel(Model model) 
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Execute("insert into Model(Id, BodyId, Id, Color, IsNew, BrandId) values(@Id, @BodyId, @Id, @Color, @IsNew, @BrandId)",
                new
                {
                    bodyId = model.BodyId,
                    color = model.Color,
                    isNew = model.IsNew,
                    brandId = model.BrandId,
                    
                });

        }
    }
}