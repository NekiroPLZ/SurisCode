using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suris_Code.Repository;

namespace Suris_Code.Controllers
{
    [Route("api/vendedor")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        [HttpGet("vendedores")]
        public ActionResult ObtenerVendedores()
        {
            var listaVendedores = VendedoresRepository.Vendedores;
            return Ok(listaVendedores);
        }
    }
}
