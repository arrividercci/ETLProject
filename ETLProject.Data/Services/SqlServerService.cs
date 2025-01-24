using Microsoft.Data.SqlClient;
using System.Data;

namespace ETLProject.Data.Services
{
    public class SqlServerService : DbService
    {
        public SqlServerService(string connectionString) : base(connectionString)
        {
        }

        public async override Task ExecuteAsync(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var сommand = new SqlCommand(query, connection);
                await сommand.ExecuteNonQueryAsync();
            }
        }

        public async override Task InsertDataAsync(string tableName, DataTable dataTable)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                

                using (var bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = tableName;
                    await bulkCopy.WriteToServerAsync(dataTable);
                }
            }
        }
    }
}
