using Books.Entities;
using Books.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Tests.Persistence
{
    [TestClass]
    public class InMemoryBookRepositoryTests
    {
        [TestMethod]
        public void AddingNewBookMakesItPersistent()
        {
            var repo = new InMemoryRepository<Book>();
            var newBook = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Baltagul",
                Authors = new List<string> { "Mihail Sadoveanu" }
            };

            repo.Add(newBook);

            // create new instance of repo
            var newRepo = new InMemoryRepository<Book>();
            var persistedBook = newRepo.GetById(newBook.Id);

            Assert.AreEqual(newBook.Id, persistedBook.Id);
            Assert.AreEqual(newBook.Title, persistedBook.Title);
        }

        [TestMethod]
        public void CannotUpdateBookNotInRepo()
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Growing Object-Oriented Software, Guided by Tests",
                Authors = new List<string> { "Steve Freeman", "Nat Pryce" }
            };

            var repo = new InMemoryRepository<Book>();

            try
            {
                repo.Update(book);
                Assert.Fail("Update did not throw exception for missing book");
            }
            catch (MissingEntityException)
            {
                Assert.IsTrue(true, "Cannot update book not in repo");
            }
        }

        [TestMethod]
        public void CanUpdateBookInRepo()
        {
            var repo = new InMemoryRepository<Book>();
            var book = repo.GetAll().First();

            var updatedBook = new Book {
                Id = book.Id,
                Title = book.Title,
                Subtitle = book.Subtitle + "(2nd ed.)",
                Publisher = book.Publisher,
                Authors = new List<string>(book.Authors)
            };

            repo.Update(updatedBook);

            // create new instance of repo
            var newRepo = new InMemoryRepository<Book>();
            var persistedUpdatedBook = newRepo.GetById(updatedBook.Id);

            Assert.AreEqual(updatedBook.Subtitle, persistedUpdatedBook.Subtitle);
        }
    }
}
