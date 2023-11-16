using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApp.Domain.Entities
{
    [Table("Customers")]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        
        [NotMapped]
        public Address Address { get; set; }
    }
}
