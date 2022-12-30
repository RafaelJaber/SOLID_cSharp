using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultProdutoService : IProdutoService
    {
        private readonly ICategoriaRepository _repository;
        private readonly ILeilaoRepository _leilaoRepository;

        public DefaultProdutoService(ICategoriaRepository repository, ILeilaoRepository leilaoRepository)
        {
            _repository = repository;
            _leilaoRepository = leilaoRepository;
        }

        public IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo)
        {
            var termoNormalized = termo.ToUpper();
            return _leilaoRepository
                .BuscarTodos()
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descricao.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descricao.ToUpper().Contains(termoNormalized));
        }

        public IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao()
        {
           return _repository
               .BuscarTodos()
               .Select(c => new CategoriaComInfoLeilao
               {
                   Id = c.Id,
                   Descricao = c.Descricao,
                   Imagem = c.Imagem,
                   EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                   EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                   Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
               });
        }

        public Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id)
        {
            return _repository.BusarPorId(id);
        }
    }
}
