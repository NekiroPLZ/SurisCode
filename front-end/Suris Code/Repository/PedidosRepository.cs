using Suris_Code.Models;
using System.Text.Json;

namespace Suris_Code.Repository
{
    public static class PedidosRepository
    {
        public static List<Pedido> Pedidos { get; set; }

        static PedidosRepository()
        {
            LeerPedidos();
        }

        private static void LeerPedidos()
        {
            string direccionArchivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "pedidos.json");
            string datosJson = File.ReadAllText(direccionArchivo);

            var data = JsonSerializer.Deserialize<Dictionary<string, List<Pedido>>>(datosJson);
            Pedidos = data["pedidos"];
        }
        public static void GuardarPedidos()
        {
            string direccionArchivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "pedidos.json");
            var nuevosDatos = new Dictionary<string, List<Pedido>>
            {
                {"pedidos",Pedidos }
            };
            string jsonDatosAgregados = JsonSerializer.Serialize(nuevosDatos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(direccionArchivo, jsonDatosAgregados);
        }
    }
}
