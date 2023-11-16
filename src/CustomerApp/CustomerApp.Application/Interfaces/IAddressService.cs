using CustomerApp.Application.DTOs;
using CustomerApp.Domain.Entities;

namespace CustomerApp.Application.Interfaces
{
    public interface IAddressService
    {
        Task<AddressDTO> GetAddressByCustomerId(int id);
        Task<AddressDTO> CreateAddress(AddressDTO address, int customerId);
        Task<AddressDTO> UpdateAddress(AddressDTO address);
        Task RemoveAddress(int id);
        Task<AddressDTO> GetAddressByApi(string baseUrl, string cep);
    }
}
