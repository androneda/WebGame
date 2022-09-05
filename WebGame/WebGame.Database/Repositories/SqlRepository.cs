using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class SqlRepository : ISqlRepository
    {
        private readonly string cs;
        IConfiguration config;
        public SqlRepository(WebGameDBContext context, IConfiguration configuration)
        {
            config = configuration;
            cs = config.GetConnectionString("WebGameData");
        }

        public async Task<DataSet> GetByQuerySql(string query)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();
            using var command = new NpgsqlCommand(query, con);

            await command.PrepareAsync();

            DataSet dataSet = new DataSet();

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);

            dataAdapter.Fill(dataSet);

            return dataSet;
        }
    }
}
