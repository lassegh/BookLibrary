using System;
using BookLibrary;
using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookLibraryTest
{
    /// <summary>
    /// Test af bogklassen i BookLibrary
    /// </summary>
    [TestClass]
    public class BookTest
    {
        Book book;

        [TestInitialize]
        public void Init()
        {
            book = new Book();
        }

        [TestMethod]
        public void TestTitlePass() // Tester en titel med 2 chars - dette er minimumskravet
        {
            book.Title = "Aa";
            Assert.AreEqual("Aa",book.Title);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestTitleFail() // Tester titel med 1 char - dette er lige på den forkerte side af det tilladte
        {
            book.Title = "A";
        }

        [TestMethod]
        public void TestAuthor() // Tester getter og setter på Author
        {
            book.Author = "LG";
            Assert.AreEqual("LG",book.Author);
        }

        [TestMethod]
        public void TestPagesPass() // Tester de to tilladte yderpunkter på antal af sider
        {
            book.NumberOfPages = 10;
            Assert.AreEqual(10,book.NumberOfPages);
            book.NumberOfPages = 1000;
            Assert.AreEqual(1000,book.NumberOfPages);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestPagesFailOne() // Tester at der kommer exception på den ene forkerte side af det tilladte antal sider
        {
            book.NumberOfPages = 9;
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void TestPagesFailTwo() // Tester at der kommer exception på den anden forkerte side af det tilladte antal sider
        {
            book.NumberOfPages = 1001;
        }

        [TestMethod]
        public void TestIsbnPass() // Tester ISBN med de tilladte 13 chars
        {
            book.ISbn = "0123456789123";
            Assert.AreEqual("0123456789123",book.ISbn);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestIsbnFailOne() // Tester ISBN med 14 chars
        {
            book.ISbn = "01234567891234";
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestIsbnFailTwo() // Tester ISBN med 12 chars
        {
            book.ISbn = "012345678912";
        }

        [TestMethod]
        public void TestConstructor() // Tester parameterfyldt konstruktør
        {
            Book myBook = new Book("Aa",10,"0123456789123","LG");
            Assert.AreEqual(10,myBook.NumberOfPages);
            Assert.AreEqual("Aa",myBook.Title);
            Assert.AreEqual("0123456789123",myBook.ISbn);
            Assert.AreEqual("LG",myBook.Author);
        }
    }
}
