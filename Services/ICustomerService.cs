using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapProject.Domain;

namespace AutoMapProject.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int customerId);
        Task<bool> CreateCustomerAsync(Customer customer);
    }
}
