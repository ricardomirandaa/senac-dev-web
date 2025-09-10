using MeuCorre.Application.UseCases.Usuarios.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MeuCorre.Controllers
{ 
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController
    {
        ///<summary>
        ///Cria um novo usuário.
        ///<param name="command"></param>
        ///</summary>
        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioCommand command)
        {

        }
    }
}
