using System.Collections.Generic;
using System.Threading.Tasks;
using POSSample.Model;

namespace POSSample.UI.Data
{
    public interface ICustomerDataService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<Customer> DeleteCustomerAsync(Customer customer);
        Task<List<Customer>> SearchCustomerAsync(string name);
    }
}