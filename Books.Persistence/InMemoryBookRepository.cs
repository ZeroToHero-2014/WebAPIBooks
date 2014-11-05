using Books.Entities;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Books.Persistence
{
    using System.Collections.Generic;

    public class InMemoryRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private static readonly ConcurrentDictionary<Guid, IEntity> Entities
            = new ConcurrentDictionary<Guid, IEntity>();

        private static Publisher Avon = new Publisher { Id = Guid.NewGuid(), Name = "Avon" };

        private static Publisher Pantheon = new Publisher { Id = Guid.NewGuid(), Name = "Pantheon Books" };

        static InMemoryRepository()
        {
            // don't do this in real life
            if (typeof(TEntity) == typeof(Book))
            {
                var cryptonomicon = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Cryptonomicon",
                    Authors = new List<string> { "Neal Stephenson" },
                    Publisher = Avon
                };
                // we're inside the static constructor, so we're guaranteed exclusive access;
                // therefore there's no need to check the return value of TryAdd
                Entities.TryAdd(cryptonomicon.Id, cryptonomicon);


                var habibi = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Habibi",
                    Authors = new List<string> { "Craig Thompson" },
                    Publisher = Pantheon
                };
                // we're inside the static constructor, so we're guaranteed exclusive access;
                // therefore there's no need to check the return value of TryAdd
                Entities.TryAdd(habibi.Id, habibi);
            }

            if (typeof(TEntity) == typeof(Publisher))
            {
                // we're inside the static constructor, so we're guaranteed exclusive access;
                // therefore there's no need to check the return value of TryAdd
                Entities.TryAdd(Avon.Id, Avon);
                Entities.TryAdd(Pantheon.Id, Pantheon);
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.Values.Cast<TEntity>().AsQueryable();
        }

        public TEntity GetById(Guid id)
        {
            IEntity entity;
            if (Entities.TryGetValue(id, out entity))
            {
                return (TEntity)entity;
            }

            return null;
        }

        public void Add(TEntity newEntity)
        {
            // TODO: treat the case when the key already exists (TryAdd returns false)
            Entities.TryAdd(newEntity.Id, newEntity);
        }


        public void Update(TEntity entity)
        {
            Entities.AddOrUpdate(
                entity.Id,
                // we expect the key to be present,
                // so if it's not, throw exception
                addValueFactory: _ => { throw new MissingEntityException(); },
                updateValueFactory: (id, oldEntity) => entity);
        }

        public void Delete(Guid id)
        {
            IEntity existingEntity;
            // ignore missing value: someone tried to delete non existent entity,
            // but we don't care
            Entities.TryRemove(id, out existingEntity);
        }
    }
}
