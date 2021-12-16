using System.Threading;
using System.Threading.Tasks;
using ICustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace ICustomerService.Data
{
    public interface IDataContext
    {
         DbSet<Customer> Customers { get; set; }

         Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}