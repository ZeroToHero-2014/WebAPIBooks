using Books.Entities;
using Books.Persistence;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Books.Api.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookRepository bookRepository;

        public BooksController()
        {
            bookRepository = new InMemoryBookRepository();
        }

        // GET: api/Books
        public IEnumerable<Book> Get()
        {
            return bookRepository.GetAll();
        }

        // GET: api/Books/c2677ee2-02ad-44dc-93b1-e64a2b57f3fe
        public Book Get(Guid id)
        {
            throw new NotImplementedException("Don't know yet how to get book by id");
        }

        // POST: api/Books
        // TODO: make this not-void; return location of new book
        public void Post([FromBody]Book newBook)
        {
            throw new NotImplementedException("Don't know yet how to persist a new book");
        }

        // PUT: api/Books/c2677ee2-02ad-44dc-93b1-e64a2b57f3fe
        public void Put(Guid id, [FromBody]Book book)
        {
            throw new NotImplementedException("Don't know yet how to update a book");
        }

        // DELETE: api/Books/c2677ee2-02ad-44dc-93b1-e64a2b57f3fe
        public void Delete(Guid id)
        {
            throw new NotImplementedException("Don't know yet how to delete a book");
        }
    }
}
