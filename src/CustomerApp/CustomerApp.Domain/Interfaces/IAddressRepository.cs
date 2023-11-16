using CustomerApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Domain.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> CreateAddressAsync(Address address);
        Task<Address> UpdateAddressAsync(Address address);
        Task<Address> RemoveAddressAsync(int id);
    }
}
