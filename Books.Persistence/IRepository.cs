using Books.Entities;
using System;
using System.Linq;

namespace Books.Persistence
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);

        void Add(TEntity newEntity);
        void Update(TEntity entity);

        void Delete(Guid id);
    }
}
