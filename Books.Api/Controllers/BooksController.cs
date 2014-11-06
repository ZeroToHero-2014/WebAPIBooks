﻿using System.Net;
﻿using System.Net.Http;
﻿using Books.Entities;
using Books.Persistence;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Books.Api.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IRepository<Book> bookRepository;

        public BooksController()
        {
            bookRepository = new InMemoryRepository<Book>();
        }

        // GET: api/Books
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, bookRepository.GetAll());

            response.Content.Headers.Add("X-Custom-Header", "Zero to Hero 2014");

            return response;
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
        public IHttpActionResult Put(Guid id, [FromBody]Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("ids don't match");
            }
            try
            {
                bookRepository.Update(book);
                return Ok(book);
            }
            catch (MissingEntityException)
            {
                return NotFound();
            }
        }

        // DELETE: api/Books/c2677ee2-02ad-44dc-93b1-e64a2b57f3fe
        public IHttpActionResult Delete(Guid id)
        {
            bookRepository.Delete(id);

            return Ok();
        }
    }
}
