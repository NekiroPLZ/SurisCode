using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Suris_Code.Models;
using Suris_Code.Repository;

namespace Suris_Code.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        [HttpPost("crearpedido")]
        public ActionResult CrearPedido([FromBody] Pedido pedido)
        {
            var articuloElegido = ArticulosRepository.Articulos.Where(x => pedido.ArticulosCodigo.Contains(x.Codigo)).ToList();

            if (pedido == null || pedido.ArticulosCodigo == null || !pedido.ArticulosCodigo.Any()) {
                return BadRequest("Pedido invalido o no contiene articulos");
            }
            var codigoInvalido = pedido.ArticulosCodigo.Except(articuloElegido.Select(x => x.Codigo)).ToList();
            if (codigoInvalido.Any())
            {
                return BadRequest($"El codigo no es valido");
            }
            PedidosRepository.Pedidos.Add(new Pedido
            {
                ArticulosCodigo = pedido.ArticulosCodigo
            });

            PedidosRepository.GuardarPedidos();

            var finalMessage = "Pedido realizado correctamente";
            return Ok(finalMessage);
        }
    }
}
