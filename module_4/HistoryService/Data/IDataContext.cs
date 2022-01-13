using System.Threading;
using System.Threading.Tasks;
using HistoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace HistoryService.Data
{
    public interface IDataContext
    {
         DbSet<History> History { get; set; }

         Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}