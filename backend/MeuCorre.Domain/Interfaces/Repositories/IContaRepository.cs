using MeuCorre.Domain.UseCases.Contas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Domain.Interfaces.Repositories
{
    public interface IContaRepository
    {
        //Adiciona uma nova conta no banco de dados
        Task<Conta> AdicionarAsync(Conta conta);
        
        //Atualiza os dados de uma categoria no banco de dados
        Task<Conta> AtualizarAsync(Conta conta);
        
        //Remove uma categoria do banco de dados
        Task<Conta> RemoverAsync(Conta conta);
    }
}
