using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CustomerApp.Domain.Entities
{
    [Table("Addresses")]
    public class Address
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public int CustommerId { get; set; }

        [JsonPropertyName("cep")]
        public string Cep {  get; set; }

        [JsonPropertyName("logradouro")]
        public string MainAddress { get; set; }

        [JsonPropertyName("complemento")]
        public string Complement { get; set; }

        [JsonPropertyName("bairro")]
        public string Neighborhood { get; set; }

        [JsonPropertyName("localidade")]
        public string City { get; set; }

        [JsonPropertyName("uf")]
        public string State { get; set; }

        [JsonPropertyName("ibge")]
        [NotMapped]
        public int Ibge { get; set; }

        [JsonPropertyName("guia")]
        [NotMapped]
        public int Guide { get; set; }

        [JsonPropertyName("ddd")]
        [NotMapped]
        public int CityPhoneCode { get; set; }

        [JsonPropertyName("siafi")]
        [NotMapped]
        public int Siafi {  get; set; }
    }
}
