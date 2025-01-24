using System.Data;

namespace ETLProject.Data.Interfaces
{
    public interface IDbService
    {
        Task ExecuteAsync(string query);
        Task InsertDataAsync(string tableName, DataTable dataTable);
    }
}
