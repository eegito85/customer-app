using AutoMapper;
using CustomerApp.Application.DTOs;
using CustomerApp.Application.Interfaces;
using CustomerApp.Domain.Entities;
using CustomerApp.Domain.Interfaces;
using Newtonsoft.Json;

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

        public async Task<AddressDTO> CreateAddress(AddressDTO address, int customerId)
        {
            var addressEntity = _mapper.Map<Address>(address);
            addressEntity.CustommerId = customerId;
            addressEntity = await _addressRepository.CreateAddressAsync(addressEntity);
            return _mapper.Map<AddressDTO>(addressEntity);
        }

        public async Task<AddressDTO> GetAddressByApi(string baseUrl, string cep)
        {
            string apiUrl = baseUrl + $"{cep}/json/";
            Address address = new Address();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string conteudo = await response.Content.ReadAsStringAsync();
                        address = JsonConvert.DeserializeObject<Address>(conteudo);
                    }
                    else
                    {
                        throw new Exception($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro: {ex.Message}");
                }
            }
            return _mapper.Map<AddressDTO>(address);
        }

        public async Task<AddressDTO> GetAddressByCustomerId(int id)
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
