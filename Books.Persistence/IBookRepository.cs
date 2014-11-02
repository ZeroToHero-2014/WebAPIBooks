using Books.Entities;
using System.Linq;

namespace Books.Persistence
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();
    }
}
