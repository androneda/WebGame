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

        public HeroRepository(WebGameDBContext context, IConfiguration configuration) : base(context)
        {

        }

    }
}
