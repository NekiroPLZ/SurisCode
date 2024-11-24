using Suris_Code.Models;
using System.Text.Json;

namespace Suris_Code.Repository
{
    public static class ArticulosRepository
    {
        public static List<Articulo> Articulos { get; set; }

        static ArticulosRepository()
        {
            LeerArticulo();
        }
        private static void LeerArticulo()
        {
            string direccionArchivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "articulos.json");
            string datosJson = File.ReadAllText(direccionArchivo);

            var data = JsonSerializer.Deserialize<Dictionary<string, List<Articulo>>>(datosJson);
            Articulos = data["articulos"]
                    .Where(x => x.Deposito == 1 && !CheckCaracteresEspeciales(x.Descripcion) && !CheckCaracteresEspeciales(x.Codigo) && x.Precio > 0)
                    .GroupBy(x => x.Codigo)
                    .Select(x => x.First()).ToList();

        }
        private static bool CheckCaracteresEspeciales(string input)
        {
            var check = input.Any(ch => !char.IsWhiteSpace(ch) && !char.IsLetterOrDigit(ch));

            return check;
        }
    }
}
