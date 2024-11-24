using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suris_Code.Models;
using Suris_Code.Repository;

namespace Suris_Code.Controllers
{
    [Route("api/articulo")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        [HttpGet("articulos")]
        public ActionResult Get()
        {
            var articulosData = ArticulosRepository.Articulos;
            return Ok(articulosData);
        }
    }
}
