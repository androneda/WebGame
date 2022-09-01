using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class RaceRepository : BaseRepository<Race>, IRaceRepository
    {
        public RaceRepository(WebGameDBContext context) : base(context)
        {

        }
    }
}
