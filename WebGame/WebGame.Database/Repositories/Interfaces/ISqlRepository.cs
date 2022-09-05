using System.Data;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface ISqlRepository
    {
        Task<DataSet> GetByQuerySql(string query); 
    }
}
