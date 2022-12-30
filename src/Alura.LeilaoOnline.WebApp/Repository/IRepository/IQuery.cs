using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Repository.IRepository
{
    public interface IQuery<T>
    {
        IEnumerable<T> BuscarTodos();
        T BusarPorId(int id);
    }
}
