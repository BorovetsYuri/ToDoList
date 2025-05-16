using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ToDoList.Configuration;
using ToDoList.DatebaseAccess.Interfaces;
using ToDoList.Models;

namespace ToDoList.DatebaseAccess.DataProviders
{
    public class CategoryDataProvider : ICategoryDataProvider
    {
        private readonly string _connectionString;
        public CategoryDataProvider(IOptions<DatabaseOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }
        public List<Category> GetAllCategories()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Category>("SELECT * FROM Categories").ToList();
        }
        public Category AddCategory(Category category)
        {
            var sql = @"
                INSERT INTO Categories (Name)
                OUTPUT INSERTED.* 
                VALUES (@Name)";
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingle<Category>(sql, category);
        }
        public Category UpdateCategory(Category category)
        {
            var sql = @"
                UPDATE Categories 
                SET Name = @Name
                OUTPUT INSERTED.* 
                WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingle<Category>(sql, category);
        }
        public void DeleteCategory(int id)
        {
            var sql = "DELETE FROM Categories WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql, new { Id = id });
        }
    }
}
