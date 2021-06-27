using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManager;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System;
using System.Linq;

namespace LibraryManager_Tests
{
    [TestClass]
    public class LibraryManagerTests
    {
        [TestMethod]
        public void FiltherByAuthorTest()
        {
            string author = "tol";
            FilterService filterService = new FilterService();
            List<Book> books = new List<Book>();
            Book book1 = new Book
            {
                Name = "ragana",
                Author = "liucija",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "111"
            };
            Book book2 = new Book
            {
                Name = "ragana",
                Author = "tolkin",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "113"
            };
            books.Add(book1);
            books.Add(book2);
            List<Book> expectedList = new List<Book>();
            expectedList.Add(book2);

            CollectionAssert.AreEqual(expectedList, filterService.filterByAuthor(author, books));
            
        }
        [TestMethod]
        public void FilterByCategoryTest()
        {
            string category = "roman";
            FilterService filterService = new FilterService();
            List<Book> books = new List<Book>();
            Book book1 = new Book
            {
                Name = "ragana",
                Author = "liucija",
                Category = "roman",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "111"
            };
            Book book2 = new Book
            {
                Name = "ragana",
                Author = "tolkin",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "113"
            };
            books.Add(book1);
            books.Add(book2);
            List<Book> expectedList = new List<Book>();
            expectedList.Add(book1);

          
            CollectionAssert.AreEqual(expectedList, filterService.filterByCategory(category, books));

        }
        [TestMethod]
        public void FiltherByLanguageTest()
        {
            string language = "english";
            FilterService filterService = new FilterService();
            List<Book> books = new List<Book>();
            Book book1 = new Book
            {
                Name = "ragana",
                Author = "liucija",
                Category = "novel",
                Language = "lithuanian",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "111"
            };
            Book book2 = new Book
            {
                Name = "ragana",
                Author = "tolkin",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "113"
            };
            books.Add(book1);
            books.Add(book2);
            List<Book> expectedList = new List<Book>();
            expectedList.Add(book2);

            CollectionAssert.AreEqual(expectedList, filterService.filterByLanguage(language, books));

        }
        [TestMethod]
        public void FiltherByISBNTest()
        {
            string isbn = "113";
            FilterService filterService = new FilterService();
            List<Book> books = new List<Book>();
            Book book1 = new Book
            {
                Name = "ragana",
                Author = "liucija",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "111"
            };
            Book book2 = new Book
            {
                Name = "ragana",
                Author = "tolkin",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "113"
            };
            books.Add(book1);
            books.Add(book2);
            List<Book> expectedList = new List<Book>();
            expectedList.Add(book2);

            CollectionAssert.AreEqual(expectedList, filterService.filterByISBN(isbn, books));

        }
        [TestMethod]
        public void FiltherByNameTest()
        {
            string name = "pabais";
            FilterService filterService = new FilterService();
            List<Book> books = new List<Book>();
            Book book1 = new Book
            {
                Name = "pabaisa",
                Author = "liucija",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "111"
            };
            Book book2 = new Book
            {
                Name = "ragana",
                Author = "tolkin",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "113"
            };
            books.Add(book1);
            books.Add(book2);
            List<Book> expectedList = new List<Book>();
            expectedList.Add(book1);

            CollectionAssert.AreEqual(expectedList, filterService.filterByName(name, books));

        }
        [TestMethod]
        public void ShowAllBooksTest()
        {
            
            FilterService filterService = new FilterService();
            List<Book> books = new List<Book>();
            Book book1 = new Book
            {
                Name = "ragana",
                Author = "liucija",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "111"
            };
            Book book2 = new Book
            {
                Name = "ragana",
                Author = "tolkin",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "113"
            };
            books.Add(book1);
            books.Add(book2);
            List<Book> expectedList = new List<Book>();
            expectedList.Add(book1);
            expectedList.Add(book2);

            CollectionAssert.AreEqual(expectedList, filterService.showBooks(books));

        }
        [TestMethod]
        public void FilterTakenBooksTest()
        {

            FilterService filterService = new FilterService();
            List<Book> books = new List<Book>();
            Book book1 = new Book
            {
                Name = "ragana",
                Author = "liucija",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "111",
                BookStatus = Status.NOT_TAKEN
            };
            Book book2 = new Book
            {
                Name = "ragana",
                Author = "tolkin",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "113",
                BookStatus = Status.TAKEN
            };
            books.Add(book1);
            books.Add(book2);
            List<Book> expectedList = new List<Book>();
            expectedList.Add(book2);

            CollectionAssert.AreEqual(expectedList, filterService.filterTaken(books));

        }
        [TestMethod]
        public void FilterNotTakenBooksTest()
        {

            FilterService filterService = new FilterService();
            List<Book> books = new List<Book>();
            Book book1 = new Book
            {
                Name = "ragana",
                Author = "liucija",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "111",
                BookStatus = Status.NOT_TAKEN
            };
            Book book2 = new Book
            {
                Name = "ragana",
                Author = "tolkin",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "113",
                BookStatus = Status.TAKEN
            };
            books.Add(book1);
            books.Add(book2);
            List<Book> expectedList = new List<Book>();
            expectedList.Add(book1);

            CollectionAssert.AreEqual(expectedList, filterService.filterNotTaken(books));

        }
        [TestMethod]
        public void TakeBookTestChangesStatus()
        {
            LibraryService libraryService = new LibraryService();
            List<Book> books = new List<Book>();
            List<BorrowDetails> borrowDetails = new List<BorrowDetails>(); 
            Book book1 = new Book
            {
                Name = "ragana",
                Author = "liucija",
                Category = "novel",
                Language = "english",
                PublicationDate = DateTime.Parse("2000-01-11"),
                ISBN = "111",
                BookStatus = Status.NOT_TAKEN
            };
          
            books.Add(book1);
            
            libraryService.takeBook("1", "111", "2021-07-07",books, borrowDetails);
            var book = books.Where(i => i.ISBN == "111").First();

            Assert.AreEqual(Status.TAKEN, book.BookStatus);
        }

    }
}
