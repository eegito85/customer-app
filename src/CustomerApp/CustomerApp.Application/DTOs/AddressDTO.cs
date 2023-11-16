using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CustomerApp.Application.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public int CustommerId { get; set; }
        public string Cep { get; set; }
        public string MainAddress { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Ibge { get; set; }
        public int Guide { get; set; }
        public int CityPhoneCode { get; set; }
        public int Siafi { get; set; }
    }
}
