using MediatR;
using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Usuarios.Commands
{
    public class AtualizarUsuarioCommand : IRequest<(string, bool)>
    {
        [Required(ErrorMessage = "Nome é obrigátorio")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigátorio")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigátorio")]
        public required DateTime DataNascimento { get; set; }
    }

    internal class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, (string, bool)>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AtualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<(string, bool)> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioExistente = await _usuarioRepository.ObterUsuarioPorId(request.Id);
            if (usuarioExistente != null)
            {
                return ("Já existe um usuário com este email.", false);
            }

            var atualizarUsuario = new Usuario(
                request.Nome,
                request.Email,
                string.Empty,
                request.DataNascimento,
                true);

            await _usuarioRepository.AtualizarUsuarioAync(atualizarUsuario);
            return ("Usuário criado com sucesso.", true);
        }
    }
}
