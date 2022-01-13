using System.Threading.Tasks;
using CustomerService.Models;

namespace CustomerService.Services
{
    public interface ICustomerRepository
    {
         Task<Customer> Get(int id);

         Task Add(Customer customer);
    }
}