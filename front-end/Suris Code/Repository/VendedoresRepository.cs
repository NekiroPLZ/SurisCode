using Suris_Code.Models;
using System.Text.Json;

namespace Suris_Code.Repository
{
    public static class VendedoresRepository
    {
        public static List<Vendedor> Vendedores { get; set; }
        static VendedoresRepository()
        {
            LeerVendedores();
        }
        private static void LeerVendedores()
        {
            string direccionArchivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "vendedores.json");
            string datosJson = File.ReadAllText(direccionArchivo);

            var data = JsonSerializer.Deserialize<Dictionary<string, List<Vendedor>>>(datosJson);
            Vendedores = data["vendedores"];
        }
    }
}
