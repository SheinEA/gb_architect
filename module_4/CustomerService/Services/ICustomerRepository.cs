using System.Threading.Tasks;
using ICustomerService.Models;

namespace ICustomerService.Services
{
    public interface ICustomerRepository
    {
         Task<Customer> Get(int id);

         Task Add(Customer customer);
    }
}