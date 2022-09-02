using System.Data;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface IHeroRepository : IBaseRepository<Hero>
    {
        Task<DataSet> GetAllSql(); 
    }
}
