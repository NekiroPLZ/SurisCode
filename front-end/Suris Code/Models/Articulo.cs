namespace Suris_Code.Models;
using System.Text.Json.Serialization;

public class Articulo
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; }

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; }

    [JsonPropertyName("precio")]
    public decimal Precio { get; set; }

    [JsonPropertyName("deposito")]
    public int Deposito { get; set; }
}
