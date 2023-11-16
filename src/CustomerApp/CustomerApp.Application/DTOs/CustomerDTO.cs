using CustomerApp.Domain.Entities;

namespace CustomerApp.Application.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public AddressDTO Address { get; set; }
    }
}
