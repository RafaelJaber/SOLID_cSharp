using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Repository.IRepository;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {

        private readonly ILeilaoRepository _repository;

        public DefaultAdminService(ILeilaoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _repository.BuscarCategorias();
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _repository.BuscarLeiloes();
        }

        public Leilao ConsultaPorId(int id)
        {
            return _repository.BuscarPorId(id);
        }

        public void CadastraLeilao(Leilao leilao)
        {
            _repository.Incluir(leilao);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            _repository.Editar(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                _repository.Excluir(leilao);
            }
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            Leilao leilao = _repository.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _repository.Editar(leilao);
            }
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            Leilao leilao = _repository.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _repository.Editar(leilao);
            }
        }

        public IEnumerable<Leilao> PesquisarLeiloes(string termo)
        {
           return _repository.PesquisarLeiloes(termo);
        }
    }
}
