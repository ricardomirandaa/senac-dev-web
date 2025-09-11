using MeuCorre.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task CriarUsuarioAsync(Usuario usuario); //INSERT
        Task AtualizarUsuarioAync(Usuario usuario); //UPDATE
        Task RemoverUsuarioAsync(Usuario usuario); //DELETE

        // a ? significa que o select pode retornar nulo, ou seja, o usuario pode não ser encontrado.
        Task<Usuario?> ObterUsuarioPorEmail(string email); //SELECT 
    }
}
