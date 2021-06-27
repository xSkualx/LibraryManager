using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace LibraryManager
{
    
    public class BookService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd";
        ListWorker listWorker = new ListWorker();
        public void addBook(string newName, string newAuthor, string newCategory, string newLanguage, string newPublicationDate, string newIsbn, List<Book>books)
        {
            if (string.IsNullOrEmpty(newName)|| string.IsNullOrEmpty(newAuthor) || string.IsNullOrEmpty(newCategory)|| string.IsNullOrEmpty(newLanguage) || string.IsNullOrEmpty(newPublicationDate) || string.IsNullOrEmpty(newIsbn))
            {
                Console.WriteLine("One or more arguments was not typed in");
                return;
            }
            DateTime theDate;
            bool result = DateTime.TryParseExact(
                newPublicationDate,
                DATE_FORMAT,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out theDate);
            if (!result)
            {
                Console.WriteLine("Invalid date!");
                return;

            }
            var book = new Book {
                Name = newName,
                Author = newAuthor,
                Category = newCategory,
                Language = newLanguage,
                PublicationDate = theDate,
                ISBN = newIsbn
            };
            books.Add(book);
            listWorker.writeBooksList(books);
            Console.WriteLine("Book successfully added!");
        }
        public void deleteBook(string isbn, List<Book> books)
        {
            var book = books.Where(i => i.ISBN == isbn).FirstOrDefault();
            if (book.Equals(null))
            {
                Console.WriteLine("Book was not found");
                return;
            }
            else
            {
                books.Remove(book);
            }
            listWorker.writeBooksList(books);
            Console.WriteLine("Book successfully removed!");
        }
       
    }
}
