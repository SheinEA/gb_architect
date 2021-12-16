using System.Threading.Tasks;
using ICustomerService.Data;
using ICustomerService.Models;

namespace ICustomerService.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataContext _context;

        public CustomerRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> Get(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
    }
}