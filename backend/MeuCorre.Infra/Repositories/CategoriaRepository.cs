using MeuCorre.Domain.Entities;
using MeuCorre.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Infra.Repositories
{
    public class CategoriaRepository
    {
        private readonly MeuDbContext _meuDbContext;
        public CategoriaRepository(MeuDbContext meuDbContext)
        {
            _meuDbContext = meuDbContext;
        }

        public async Task CriarCategoriaAsync(Categoria categoria)
        {
            await _meuDbContext.Categorias.AddAsync(categoria);
            await _meuDbContext.SaveChangesAsync();
        }

        public async Task AtualizarCategoriaAsync(Categoria categoria)
        {
            _meuDbContext.Categorias.Update(categoria);
            await _meuDbContext.SaveChangesAsync();
        }

        public async Task<Categoria?> ObterCategoriaPorId(Guid id)
        {
            return await _meuDbContext.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task RemoverCategoriaAsync(Categoria categoria)
        {
            _meuDbContext.Categorias.Remove(categoria);
            await _meuDbContext.SaveChangesAsync();
        }
    }
}
