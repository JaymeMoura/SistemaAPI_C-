using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTeste.Models;

namespace SistemaTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return Ok();
        }

        ///testeeeeeee123
    }
}
