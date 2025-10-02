using MediatR;
using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Enums;
using MeuCorre.Domain.Interfaces.Repositories;
using MeuCorre.Domain.UseCases.Contas;
using System.ComponentModel.DataAnnotations;

namespace MeuCorre.Application.UseCases.Contas
{
    public class CriarContaCommand : IRequest<(string, bool)>
    {
        [Required(ErrorMessage = "O id da conta é obrigatório")]
        public required Guid ContaId { get; set; }

        [Required(ErrorMessage = "O Nome da conta é obrigatório.")]
        public required string Nome { get; set; }
        public TipoConta? Tipo { get; set; }
        public decimal? Saldo { get; set; }
        public bool? Ativo { get; set; }

        

    }
    internal class CriarContaCommandHandler : IRequestHandler<CriarContaCommand, (string, bool)>
    {
        private readonly IContaRepository _contaRepository;
        public CriarContaCommandHandler(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<(string, bool)> Handle(CriarContaCommand request, CancellationToken cancellationToken)
        {
            var contaExistente = await _contaRepository.ObterContaPorIdAsync(request.ContaId);
            if (contaExistente != null)
            {
                return ("Já existe um usuário com este email.", false);
            }

            var novaConta = new Conta(
                request.ContaId,
                request.Nome,
                request.Tipo,
                request.Saldo,
                true
                );

            await _contaRepository.CriarContaAsync(novaConta);
            return ("Conta criada com sucesso.", true);
        }
    }
}
