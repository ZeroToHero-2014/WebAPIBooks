using Books.Entities;
using System;
using System.Linq;

namespace Books.Persistence
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IQueryable<Book> GetAll();
        Book GetById(Guid id);

        void Add(Book newBook);
        void Update(Book book);

        void Delete(Guid id);
    }
}
