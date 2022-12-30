using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class ArquivamentoAdminService : IAdminService
    {
        private readonly IAdminService _defaultService;

        public ArquivamentoAdminService(ILeilaoRepository leilaoRepository)
        {
            _defaultService = new DefaultAdminService(leilaoRepository);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _defaultService.ConsultaCategorias();
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _defaultService.ConsultaLeiloes()
                .Where(l => l.Situacao != SituacaoLeilao.Arquivado);

        }

        public Leilao ConsultaPorId(int id)
        {
            return _defaultService.ConsultaPorId(id);

        }

        public void CadastraLeilao(Leilao leilao)
        {
            _defaultService.CadastraLeilao(leilao);

        }

        public void ModificaLeilao(Leilao leilao)
        {
            _defaultService.ModificaLeilao(leilao);

        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                _defaultService.ModificaLeilao(leilao);
            }

        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            _defaultService.IniciaPregaoDoLeilaoComId(id);

        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            _defaultService.FinalizaPregaoDoLeilaoComId(id);

        }

        public IEnumerable<Leilao> PesquisarLeiloes(string termo)
        {
            return _defaultService.PesquisarLeiloes(termo);
        }
    }
}
