using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class HeroRepository : BaseRepository<Hero>, IHeroRepository
    {
        private readonly string cs;
        IConfiguration config;
        public HeroRepository(WebGameDBContext context, IConfiguration configuration) : base(context)
        {
            config = configuration;
            cs = config.GetConnectionString("WebGameData");
        }

        public async Task<DataSet> GetAllSql()
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();
            using var command = new NpgsqlCommand("SELECT * FROM public.\"Heroes\"", con);

            await command.PrepareAsync();

            DataSet dataSet = new DataSet();

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);

            dataAdapter.Fill(dataSet);

            return dataSet;
        }
    }
}
