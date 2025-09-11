using MediatR;
using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Usuarios.Commands
{
    /// <summary>
    /// Comando para criar um novo usuário.
    /// Aqui você pode adicionar propriedades necessárias para a criação do usuário, como Nome, Email, Senha, etc.
    /// </summary>
    public class CriarUsuarioCommand : IRequest<(string, bool)>
    {
        [Required(ErrorMessage = "Nome é obrigátorio")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigátorio")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigátorio")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigátorio")]
        public required DateTime DataNascimento { get; set; }
    }

    internal class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, (string, bool)>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<(string, bool)> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioExistente = await _usuarioRepository.ObterUsuarioPorEmail(request.Email);
            if (usuarioExistente != null)
            {
                return ("Já existe um usuário com este email.", false);
            }

            var ano = DateTime.Now.Year;
            var idade = ano - request.DataNascimento.Year;
            if(idade < 13)
            {
                return ("O usuário deve ter no mínimo 16 anos.", false);
            }

            var novoUsuario = new Usuario(
                request.Nome, 
                request.Email, 
                request.Senha, 
                request.DataNascimento, 
                true);

            await _usuarioRepository.CriarUsuarioAsync(novoUsuario);
            return ("Usuário criado com sucesso.", true);
        }
    }
}
