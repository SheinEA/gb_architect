using System.Threading.Tasks;
using HistoryService.Data;
using HistoryService.Models;

namespace HistoryService.Services
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly IDataContext _context;

        public HistoryRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(History history)
        {
            _context.History.Add(history);
            await _context.SaveChangesAsync();
        }

        public async Task<History> Get(int id)
        {
            return await _context.History.FindAsync(id);
        }
    }
}