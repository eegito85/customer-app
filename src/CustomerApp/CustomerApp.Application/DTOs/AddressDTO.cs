using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CustomerApp.Application.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public int CustommerId { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public int Ibge { get; set; }
        public int Gia { get; set; }
        public int Ddd { get; set; }
        public int Siafi { get; set; }
    }
}
