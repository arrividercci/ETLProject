using ETLProject.Data.Interfaces;
using System.Data;

namespace ETLProject.Data.Services
{
    public abstract class DbService : IDbService
    {
        protected readonly string connectionString;
        public DbService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public abstract Task ExecuteAsync(string query);

        public abstract Task InsertDataAsync(string tableName, DataTable dataTable);
    }
}
