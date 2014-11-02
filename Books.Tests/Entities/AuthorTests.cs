using Books.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.Tests.Entities
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void UnsetSortableNameIsTheSameAsName()
        {
            var sut = new Author() { Name = "Neal Stephenson" };

            Assert.AreEqual(sut.Name, sut.SortableName);
        }

        [TestMethod]
        public void CanSetSortableNameToSomethingOtherThanName()
        {
            var sortableName = "Diamond, Jared";

            var sut = new Author() { Name = "Jared Diamond" };

            sut.SortableName = sortableName;

            Assert.AreEqual(sortableName, sut.SortableName);
            Assert.AreNotEqual(sortableName, sut.Name);
        }
    }
}
