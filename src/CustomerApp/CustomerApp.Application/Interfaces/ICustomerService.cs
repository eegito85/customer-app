using CustomerApp.Application.DTOs;

namespace CustomerApp.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomers();
        Task<CustomerDTO> GetCustomerById(int id);
        Task<CustomerDTO> CreateCustomer(CustomerDTO customer);
        Task<CustomerDTO> UpdateCustomer(CustomerDTO customer);
        Task RemoveCustomer(int id);
    }
}
