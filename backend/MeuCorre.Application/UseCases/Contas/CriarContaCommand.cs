using MediatR;
using MeuCorre.Application.UseCases.Categorias.Commands;
using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Contas
{
    public class CriarContaCommand : IRequest<(string, bool)>
    {

    }
    internal class CriarContaCommandHandler : IRequestHandler<CriarContaCommand, (string, bool)>
    {
        private readonly IContaRepository _contaRepository;
        public CriarContaCommandHandler(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public Task<(string, bool)> Handle(CriarContaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
