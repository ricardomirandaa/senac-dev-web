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
        //Adiciona uma nova conta no banco de dados.
        Task<Conta> CriarContaAsync(Conta conta);
        
        //Atualiza os dados de uma categoria no banco de dados.
        Task<Conta> AtualizarContaAsync(Conta conta);
        
        //Remove uma categoria do banco de dados.
        Task<Conta> RemoverContaAsync(Conta conta);

        //Retorna do banco de dados da conta se o Id ja existe.
        Task<Conta> ObterContaPorIdAsync(Guid contaId);
    }
}
