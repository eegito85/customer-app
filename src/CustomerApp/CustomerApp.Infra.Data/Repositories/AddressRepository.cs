using CustomerApp.Domain.Entities;
using CustomerApp.Domain.Interfaces;
using CustomerApp.Infra.Data.Context;

namespace CustomerApp.Infra.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            _context.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            var address = _context.Addresses.Where(a => a.CustommerId == id).FirstOrDefault();
            if (address == null) return new Address();
            return address;
        }

        public async Task<Address> RemoveAddressAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null) return new Address();
            _context.Remove(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            _context.Update(address);
            await _context.SaveChangesAsync();
            return address;
        }
    }
}
