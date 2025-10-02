using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeuCorre.Domain.UseCases.Contas
{
    public class Conta : Entidade
    {
        [Required(ErrorMessage = "O Nome da conta é obrigatório.")]
        public required string Nome { get; set; }
        public TipoConta? Tipo { get; set; }
        public decimal? Saldo { get; set; }
        public bool? Ativo { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public Conta(Guid ContaId, string nome, TipoConta? tipoConta, decimal? saldo, bool? ativo)
        {
            Nome = nome;
            Tipo = tipoConta;
            Saldo = saldo;
            Ativo = true;
        }
        public  void AtualizarInformacoes(string nome, TipoConta tipoConta, decimal saldo, bool ativo)
        {
            Nome = nome.ToUpper();
            Tipo = tipoConta;
            Saldo = saldo;
            Ativo = ativo;

            AtualizarDataMoficacao();
        }
        public void Ativar()
        {
            Ativo = true;
            AtualizarDataMoficacao();
        }
        public void Inativar()
        {
            Ativo = false;
            AtualizarDataMoficacao();

        }
    }
}
