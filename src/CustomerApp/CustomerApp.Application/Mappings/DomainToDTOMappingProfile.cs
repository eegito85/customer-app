using AutoMapper;
using CustomerApp.Application.DTOs;
using CustomerApp.Domain.Entities;

namespace CustomerApp.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
