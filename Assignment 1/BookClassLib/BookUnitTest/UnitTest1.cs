using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookClassLib;
using System;

namespace BookUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TitleTest()
        {
            Assert.ThrowsException<Exception>(() => { Book b = new Book("1", "Author1", 12, "111111111111"); });
        }
        [TestMethod]
        public void AuthorTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { Book b = new Book("ProperTitle", null , 12, "111111111111"); });
        }
        [TestMethod]
        public void PageTest()
        {
            Assert.ThrowsException<Exception>(() => { Book b = new Book("ProperTitle", "Author1", 1, "111111111111"); });
        }
        [TestMethod]
        public void ISBNTest()
        {
            Assert.ThrowsException<Exception>(() => { Book b = new Book("ProperTitle", "Author1", 12, "1111111111"); });
        }
    }
}
