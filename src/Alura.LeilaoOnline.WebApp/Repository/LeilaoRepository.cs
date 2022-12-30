using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Repository
{
    public class LeilaoRepository : ILeilaoRepository
    {
        private readonly AppDbContext _context;

        public LeilaoRepository()
        {
            _context = new AppDbContext();
        }
        
        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _context.Categorias.ToList();
        }

        public IEnumerable<Leilao> BuscarLeiloes()
        {
            return _context.Leiloes
                .Include(l => l.Categoria)
                .ToList();
        }

        public Leilao BuscarPorId(int id)
        {
            return _context.Leiloes.FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Leilao> PesquisarLeiloes(string termo)
        {
            var leiloes = _context.Leiloes
                .Include(l => l.Categoria)
                .Where(l => string.IsNullOrWhiteSpace(termo) || 
                            l.Titulo.ToUpper().Contains(termo.ToUpper()) || 
                            l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                            l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
            return leiloes;
        }

        public void Incluir(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }
        
        public void Editar(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void Excluir(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
