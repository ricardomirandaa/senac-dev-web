using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Interfaces.Repositories;
using MeuCorre.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MeuDbContext _meuDbContext;
        public UsuarioRepository(MeuDbContext meuDbContext)
        {
            _meuDbContext = meuDbContext;
        }

        public async Task CriarUsuarioAsync(Usuario usuario)
        {
            await _meuDbContext.Usuarios.AddAsync(usuario);
            await _meuDbContext.SaveChangesAsync();
        }

        public async Task AtualizarUsuarioAync(Usuario usuario)
        {
            _meuDbContext.Usuarios.Update(usuario);
            await _meuDbContext.SaveChangesAsync();
        }

        public async Task<Usuario?> ObterUsuarioPorEmail(string email)
        {
            return await _meuDbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task RemoverUsuarioAsync(Usuario usuario)
        {
            _meuDbContext.Usuarios.Remove(usuario);
            await _meuDbContext.SaveChangesAsync();
        }
    }
}
