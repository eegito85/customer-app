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
        [Column(name: "MainAddress")]
        public string Logradouro { get; set; }

        [JsonPropertyName("complemento")]
        [Column(name: "Complement")]
        public string Complemento { get; set; }

        [JsonPropertyName("bairro")]
        [Column(name: "Neighbohood")]
        public string Bairro { get; set; }

        [JsonPropertyName("localidade")]
        [Column(name:"City")]
        public string Localidade { get; set; }

        [JsonPropertyName("uf")]
        [Column(name: "State")]
        public string Uf { get; set; }

        [JsonPropertyName("ibge")]
        [NotMapped]
        public int Ibge { get; set; }

        [JsonPropertyName("gia")]
        [NotMapped]
        public int Gia { get; set; }

        [JsonPropertyName("ddd")]
        [NotMapped]
        public int Ddd { get; set; }

        [JsonPropertyName("siafi")]
        [NotMapped]
        public int Siafi {  get; set; }
    }
}
