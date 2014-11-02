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
        public IHttpActionResult Get(Guid id)
        {
            var book = bookRepository.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/Books
        public IHttpActionResult Post([FromBody]Book newBook)
        {
            // is this the right place to generate the id?
            newBook.Id = Guid.NewGuid();
            bookRepository.Add(newBook);

            return CreatedAtRoute("DefaultApi", new { id = newBook.Id }, newBook);
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
