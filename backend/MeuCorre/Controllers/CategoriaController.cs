using MediatR;
using MeuCorre.Application.UseCases.Categorias.Commands;
using MeuCorre.Application.UseCases.Usuarios.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MeuCorre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCategoria([FromBody] CriarCategoriaCommand command)
        {
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return Ok(mensagem);
            }
            else
            {
                return Conflict(mensagem);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCategoria(Guid id, [FromBody] AtualizarCategoriaCommand command)
        {
            command.CategoriaId = id;
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return Ok(mensagem);
            }
            else
            {
                return NotFound(mensagem);
            }
        }
    }
    
}
