using Books.Entities;
using Books.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Books.Tests.Persistence
{
    [TestClass]
    public class InMemoryBookRepositoryTests
    {
        [TestMethod]
        public void AddingNewBookMakesItPersistent()
        {
            var repo = new InMemoryBookRepository();
            var newBook = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Baltagul"
            };

            repo.Add(newBook);

            // create new instance of repo
            var newRepo = new InMemoryBookRepository();
            var persistedBook = newRepo.GetById(newBook.Id);

            Assert.AreEqual(newBook.Id, persistedBook.Id);
            Assert.AreEqual(newBook.Title, persistedBook.Title);
        }
    }
}
