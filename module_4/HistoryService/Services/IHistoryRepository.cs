using System.Threading.Tasks;
using HistoryService.Models;

namespace HistoryService.Services
{
    public interface IHistoryRepository
    {
         Task<History> Get(int id);

         Task Add(History history);
    }
}