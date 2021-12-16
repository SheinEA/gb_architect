using ICustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace ICustomerService.Data
{
    public class CustomerContext : DbContext, IDataContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}