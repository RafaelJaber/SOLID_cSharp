using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Repository.IRepository;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {

        private readonly ILeilaoRepository _repository;
        private readonly ICategoriaRepository _categoriaRepository;

        public DefaultAdminService(ILeilaoRepository repository, ICategoriaRepository categoriaRepository)
        {
            _repository = repository;
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _categoriaRepository.BuscarTodos();
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _repository.BuscarTodos();
        }

        public Leilao ConsultaPorId(int id)
        {
            return _repository.BusarPorId(id);
        }

        public void CadastraLeilao(Leilao leilao)
        {
            _repository.Incluir(leilao);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            _repository.Alterar(leilao);
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
            Leilao leilao = _repository.BusarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _repository.Alterar(leilao);
            }
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            Leilao leilao = _repository.BusarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _repository.Alterar(leilao);
            }
        }

        public IEnumerable<Leilao> PesquisarLeiloes(string termo)
        {
           return _repository.PesquisarLeiloes(termo);
        }
    }
}
