using HistoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace HistoryService.Data
{
    public class HistoryContext : DbContext, IDataContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {

        }

        public DbSet<History> History { get; set; }
    }
}