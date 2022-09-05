using Npgsql;
using System.Data;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class HeroRepository : BaseRepository<Hero>, IHeroRepository
    {
        public HeroRepository(WebGameDBContext context) : base(context)
        {

        }

        public async Task<DataSet> GetAllSql()
        {
            string cs = "User ID=postgres; Password=postgres;Host=localhost;Port=5432;Database=WebGameBD;Pooling=true";

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
