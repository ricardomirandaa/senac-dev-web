using MediatR;
using MeuCorre.Application.UseCases.Categorias.Dtos;
using MeuCorre.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Categorias.Queries
{
    public class ObterCategoriaQuery : IRequest<CategoriaDto>
    {
        [Required(ErrorMessage = "É necessario informar o id da categoria")]
        public required Guid CategoriaId { get; set; }
    }

    internal class ObterCategoriaQueryHandler : IRequestHandler<ObterCategoriaQuery, CategoriaDto>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public ObterCategoriaQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaDto> Handle(ObterCategoriaQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(request.CategoriaId);

            if (categoria == null)
                return null;

            var categoriaDto = new CategoriaDto
            { 
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
                Cor = categoria.Cor,
                Icone = categoria.Icone,
                Ativo = categoria.Ativo,
                Tipo = categoria.TipoDaTransacao,
            }; 
            return categoriaDto;
        }
    }

}
