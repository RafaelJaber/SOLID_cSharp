using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Repository.IRepository
{
    public interface ILeilaoRepository
    {
        public IEnumerable<Categoria> BuscarCategorias();
        public IEnumerable<Leilao> BuscarLeiloes();
        public Leilao BuscarPorId(int id);
        public IEnumerable<Leilao> PesquisarLeiloes(string termo);
        public void Incluir(Leilao leilao);
        public void Editar(Leilao leilao);
        public void Excluir(Leilao leilao);
    }
}
