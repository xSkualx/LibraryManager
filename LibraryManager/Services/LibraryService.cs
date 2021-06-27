using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LibraryManager
{
    public class LibraryService
    {        
        private const string DATE_FORMAT = "yyyy-MM-dd";
        private ListWorker listWorker = new ListWorker();
        public void takeBook(string id, string ISBN, string returnDate, List<Book> books, List<BorrowDetails> borrowDetails)
        {
            var count = borrowDetails.Where(i => i.ID == id).Count();
            if (string.IsNullOrEmpty(id) || count >= 3)
            {
                Console.WriteLine("ID can't be empty or the user has already borrowed 3 books");
                return;
            }
            var bookToTake = books.Where(i => i.ISBN.Equals(ISBN) && i.BookStatus == Status.NOT_TAKEN).FirstOrDefault();
            if (bookToTake == null)
            {
                Console.WriteLine("No such avaivable book was found!");
                return;
            }
            DateTime theDate;
            bool result = DateTime.TryParseExact(
                returnDate,
                DATE_FORMAT,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out theDate);
            if (string.IsNullOrEmpty(returnDate) || !result)
            {
                Console.WriteLine("Invalid date entered! ");
                return;
            }
            if (theDate.Subtract(DateTime.Now).TotalDays > 60 || theDate < DateTime.Now)
            {
                Console.WriteLine("Date exceeds 2 months / 60 days! or is a past date");
                return;
            }

            bookToTake.BookStatus = Status.TAKEN;
            var borrow = new BorrowDetails
            {
                ID = id,
                TakeTime = DateTime.Now,
                ReturnTime = theDate,
                TakenBook = bookToTake
            };
            borrowDetails.Add(borrow);
            listWorker.writeBorrowsList(borrowDetails);
            listWorker.writeBooksList(books);
            Console.WriteLine("Book successfully borrowed!");
        }
        public void returnBook(string id, string isbn, string returningDate ,List<Book> books, List<BorrowDetails> borrowDetails)
        {
            var returnedBook = borrowDetails.Where(i => i.ID == id && i.TakenBook.ISBN == isbn).FirstOrDefault();
            if (returnedBook == null)
            {
                Console.WriteLine("The book and the id were not found! Enter ID and ISBN once more");
                return;

            }

            DateTime theDate;
            bool result = DateTime.TryParseExact(
                returningDate,
                DATE_FORMAT,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out theDate);
            if (string.IsNullOrEmpty(returningDate) || !result || theDate < DateTime.Now)
            {
                Console.WriteLine("Invalid date entered! ");
                return;
            }
            if (theDate > returnedBook.ReturnTime)
            {
                Console.WriteLine("The book was returned late you little rascal!");

            }

            var bookNotTaken = books.Where(i => i.ISBN == returnedBook.TakenBook.ISBN).FirstOrDefault();
            if (bookNotTaken.Equals(null))
            {

                borrowDetails.Remove(returnedBook);
            }
            else
            {
                bookNotTaken.BookStatus = Status.NOT_TAKEN;
                borrowDetails.Remove(returnedBook);
            }

            listWorker.writeBorrowsList(borrowDetails);
            listWorker.writeBooksList(books);
            Console.WriteLine("Book successfully returned!");

        }
    }
}
