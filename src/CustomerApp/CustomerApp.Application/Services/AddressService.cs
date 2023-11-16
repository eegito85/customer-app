using AutoMapper;
using CustomerApp.Application.DTOs;
using CustomerApp.Application.Interfaces;
using CustomerApp.Domain.Entities;
using CustomerApp.Domain.Interfaces;

namespace CustomerApp.Application.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;
        private IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressDTO> CreateAddress(AddressDTO address)
        {
            var addressEntity = _mapper.Map<Address>(address);
            addressEntity = await _addressRepository.CreateAddressAsync(addressEntity);
            return _mapper.Map<AddressDTO>(addressEntity);
        }

        public Task<AddressDTO> GetAddressByApi(string cep)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressDTO> GetAddressById(int id)
        {
            var addressEntity = await _addressRepository.GetAddressByIdAsync(id);
            return _mapper.Map<AddressDTO>(addressEntity);
        }

        public async Task RemoveAddress(int id)
        {
            await _addressRepository.RemoveAddressAsync(id);
        }

        public async Task<AddressDTO> UpdateAddress(AddressDTO address)
        {
            var addressEntity = _mapper.Map<Address>(address);
            addressEntity = await _addressRepository.UpdateAddressAsync(addressEntity);
            return _mapper.Map<AddressDTO>(addressEntity);
        }
    }
}
