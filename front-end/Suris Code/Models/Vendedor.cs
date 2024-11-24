using System.Text.Json.Serialization;

namespace Suris_Code.Models
{
    public class Vendedor
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }
    }
}
