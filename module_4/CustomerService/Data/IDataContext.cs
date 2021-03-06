using System.Threading;
using System.Threading.Tasks;
using CustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Data
{
    public interface IDataContext
    {
         DbSet<Customer> Customers { get; set; }

         Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}