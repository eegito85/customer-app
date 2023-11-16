using AutoMapper;
using CustomerApp.Application.DTOs;
using CustomerApp.Application.Interfaces;
using CustomerApp.Domain.Entities;
using CustomerApp.Domain.Interfaces;

namespace CustomerApp.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> CreateCustomer(CustomerDTO customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            customerEntity = await _customerRepository.CreateCustomerAsync(customerEntity);
            return _mapper.Map<CustomerDTO>(customerEntity);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customersEntity = await _customerRepository.GetAllCustomersAsync();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customersEntity);
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            var customerEntity = await _customerRepository.GetCustomerByIdAsync(id);
            return _mapper.Map<CustomerDTO>(customerEntity);
        }

        public async Task RemoveCustomer(int id)
        {
            await _customerRepository.RemoveCustomerAsync(id);
        }

        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            customerEntity = await _customerRepository.UpdateCustomerAsync(customerEntity);
            return _mapper.Map<CustomerDTO>(customerEntity);
        }
    }
}
