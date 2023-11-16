using CustomerApp.Application.DTOs;
using CustomerApp.Domain.Entities;

namespace CustomerApp.Application.Interfaces
{
    public interface IAddressService
    {
        Task<AddressDTO> GetAddressById(int id);
        Task<AddressDTO> CreateAddress(AddressDTO address);
        Task<AddressDTO> UpdateAddress(AddressDTO address);
        Task RemoveAddress(int id);
        Task<AddressDTO> GetAddressByApi(string cep);
    }
}
