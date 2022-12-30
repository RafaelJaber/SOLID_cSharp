using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Repository.IRepository
{
    public interface ILeilaoRepository : ICommand<Leilao>, IQuery<Leilao>
    {
    public IEnumerable<Leilao> PesquisarLeiloes(string termo);
    }
}
