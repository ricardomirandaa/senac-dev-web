using MediatR;
using System;
using System.Collections.Generic;
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
    public class CriarUsuarioCommand : IRequest<string>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
