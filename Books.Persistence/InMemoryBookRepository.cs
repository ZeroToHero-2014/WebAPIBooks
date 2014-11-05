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
                Authors = new List<string> { "Neal Stephenson" },
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
                Authors = new List<string> { "Craig Thompson" },
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

        public void Add(Book newBook)
        {
            // TODO: treat the case when the key already exists (TryAdd returns false)
            books.TryAdd(newBook.Id, newBook);
        }


        public void Update(Book book)
        {
            books.AddOrUpdate(
                book.Id,
                // we expect the key to be present,
                // so if it's not, throw exception
                addValueFactory: _ => { throw new MissingBookException(); },
                updateValueFactory: (id, oldBook) => book);
        }

        public void Delete(Guid id)
        {
            Book existingBook;
            // ignore missing value: someone tried to delete non existent book,
            // but we don't care
            books.TryRemove(id, out existingBook);
        }
    }
}
