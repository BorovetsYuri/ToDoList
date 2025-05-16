using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ToDoList.Configuration;
using ToDoList.DatebaseAccess.Interfaces;
using ToDoList.DatebaseAccess.Models;
using ToDoList.Models;

namespace ToDoList.DatebaseAccess.DataProviders
{
    public class ToDoItemDataProvider : IToDoItemDataProvider
    {
        private readonly string _connectionString;
        public ToDoItemDataProvider(IOptions<DatabaseOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }
        public List<ToDoItemDBO> GetAllToDoItems()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<ToDoItemDBO>("SELECT * FROM ToDoTasks").ToList();
        }
        public ToDoItemDBO GetToDoItemById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingleOrDefault<ToDoItemDBO>("SELECT * FROM ToDoTasks WHERE Id = @Id", new { Id = id });
        }
        public ToDoItemDBO AddToDoItem(ToDoItemCreateDBO toDoItem)
        {
            var sql = @"
                INSERT INTO ToDoTasks (Title, CompletionDate, CategoryId)
                OUTPUT INSERTED.* 
                VALUES (@Title, @CompletionDate, @CategoryId)";
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingle<ToDoItemDBO>(sql, toDoItem);
        }
        public ToDoItemDBO UpdateToDoItem(ToDoItemDBO toDoItem)
        {
            var sql = @"
                UPDATE ToDoTasks 
                SET Title = @Title, CompletionDate = @CompletionDate, CategoryId = @CategoryId
                OUTPUT INSERTED.* 
                WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingle<ToDoItemDBO>(sql, toDoItem);
        }
        public ToDoItemDBO CompleteToDoItem(int id)
        {
            var sql = @"
                UPDATE ToDoTasks 
                SET CompleteDate = @CompleteDate
                OUTPUT INSERTED.* 
                WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingle<ToDoItemDBO>(sql, new
            {
                Id = id,
                CompleteDate = DateTime.Now
            });
        }
        public void DeleteToDoItem(int id)
        {
            var sql = "DELETE FROM ToDoTasks WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(sql, new { Id = id });
        }
    }
}