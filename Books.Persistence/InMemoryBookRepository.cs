using Books.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Books.Persistence
{
    public class InMemoryBookRepository : IBookRepository
    {
        private static ConcurrentDictionary<Guid, Book> books = new ConcurrentDictionary<Guid, Book>();

        static InMemoryBookRepository()
        {
            var cryptonomicon = new Book()
            {
                Id = Guid.NewGuid(),
                Title = "Cryptonomicon",
                // TODO: get Neal from Author repository
                Authors = new List<Author> { new Author { Id = Guid.NewGuid(), Name = "Neal Stephenson" } },
                // TODO: get Avon from Publisher repository
                Publisher = new Publisher { Id = Guid.NewGuid(), Name = "Avon" }
            };
            // we're inside the static constructor, so we're guaranteed exclusive access;
            // therefore there's no need to check the return value of TryAdd
            books.TryAdd(cryptonomicon.Id, cryptonomicon);

            var habibi = new Book()
            {
                Id = Guid.NewGuid(),
                Title = "Habibi",
                // TODO: get Craig from Author repository
                Authors = new List<Author> { new Author { Id = Guid.NewGuid(), Name = "Craig Thompson" } },
                // TODO: get Pantheon from Publisher repository
                Publisher = new Publisher { Id = Guid.NewGuid(), Name = "Pantheon Books" }
            };
            // we're inside the static constructor, so we're guaranteed exclusive access;
            // therefore there's no need to check the return value of TryAdd
            books.TryAdd(habibi.Id, habibi);
        }

        public IQueryable<Book> GetAll()
        {
            return books.Values.AsQueryable();
        }


        public Book GetById(Guid id)
        {
            Book book;
            if (books.TryGetValue(id, out book))
            {
                return book;
            }

            return null;
        }
    }
}
