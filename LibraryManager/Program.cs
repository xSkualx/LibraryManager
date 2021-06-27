using System;
using System.IO;

namespace LibraryManager
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            BookService bookService = new BookService();
            FilterService filterService = new FilterService();
            LibraryService libraryService = new LibraryService();
            ListWorker listWorker = new ListWorker();
            FileManager fileManager = new FileManager();
            fileManager.manageFile();
            bool logLoop = true;
            while (logLoop == true)
            {
                try
                {
                    Console.WriteLine("Welcome to Library Management system");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Press 1 to show all books\n" +
                                      "2) Press 2 to add a book\n" +
                                      "3) Press 3 to delete a book\n" +
                                      "4) Press 4 to borrow a book\n" +
                                      "5) Press 5 to return a book\n" +
                                      "6) Press 6 to filter by category\n" +
                                      "7) Press 7 to filter by author\n" +
                                      "8) Press 8 to filter by language\n" +
                                      "9) Press 9 to filter by ISBN\n" +
                                      "10) Press 10 to filter by name\n" +
                                      "11) Press 11 to show taken books\n" +
                                      "12) Press 12 to show avaivable books\n" +
                                      "13) Press 13 to exit the program\n");
                   


                    int logCase = int.Parse(Console.ReadLine());
                    switch (logCase)
                    {
                        case 1:
                            filterService.showBooks(listWorker.makeBooksList());
                            if (filterService.showBooks(listWorker.makeBooksList()) == null)
                            {
                                Console.WriteLine("No books were found");
                            }
                            else
                            {
                                foreach (var book in filterService.showBooks(listWorker.makeBooksList()))
                                    Console.WriteLine(book.ToString());
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter book's name");
                            string newName = Console.ReadLine();
                            Console.WriteLine("Enter book's author");
                            string newAuthor = Console.ReadLine();
                            Console.WriteLine("Enter book's category");
                            string newCategory = Console.ReadLine();
                            Console.WriteLine("Enter book's language");
                            string newLanguage = Console.ReadLine();
                            Console.WriteLine("Enter book's publication date (use yyyy-mm-dd format)");
                            string newPublicationDate = Console.ReadLine();
                            Console.WriteLine("Enter book's ISBN");
                            string newIsbn = Console.ReadLine();
                            bookService.addBook(newName, newAuthor, newCategory, newLanguage, newPublicationDate, newIsbn, listWorker.makeBooksList());
                            break;
                        case 3:
                            Console.WriteLine("Enter book's ISBN");
                            string isbn = Console.ReadLine();
                            bookService.deleteBook(isbn, listWorker.makeBooksList());
                            break;
                        case 4:
                            Console.WriteLine("Enter the ID of the person taking the book");
                            string id = Console.ReadLine();
                            Console.WriteLine("Enter the ISBN of the book being borrowed");
                            string ISBN = Console.ReadLine();
                            Console.WriteLine("Enter the date for the book to be returned (use yyyy-mm-dd format)");
                            string returnDate = Console.ReadLine();
                            libraryService.takeBook(id, ISBN, returnDate, listWorker.makeBooksList(), listWorker.makeBorrowsList());
                            break;
                        case 5:
                            Console.WriteLine("Enter the ID of the person returning the book");
                            string idReturn = Console.ReadLine();
                            Console.WriteLine("Enter the ISBN of the book you want to return");
                            string isbnReturn = Console.ReadLine();
                            Console.WriteLine("Enter the date of the return (use yyyy-mm-dd format)");
                            string returningDate = Console.ReadLine();
                            libraryService.returnBook(idReturn, isbnReturn, returningDate ,listWorker.makeBooksList(), listWorker.makeBorrowsList());
                            break;
                        case 6:
                            Console.WriteLine("Enter category");
                            string category = Console.ReadLine();
                            filterService.filterByCategory(category, listWorker.makeBooksList());
                            if (filterService.filterByCategory(category, listWorker.makeBooksList()) == null)
                            {
                                Console.WriteLine("No books were found");
                            }
                            else
                            {
                                foreach (var book in filterService.filterByCategory(category, listWorker.makeBooksList()))
                                    Console.WriteLine(book.ToString());
                            }
                            break;
                        case 7:
                            Console.WriteLine("Enter author's name");
                            string author = Console.ReadLine();
                            filterService.filterByAuthor(author, listWorker.makeBooksList());
                            if (filterService.filterByAuthor(author, listWorker.makeBooksList()) == null) { 
                                Console.WriteLine("No books were found");
                            }
                            else
                            {
                                foreach (var book in filterService.filterByAuthor(author, listWorker.makeBooksList()))
                                    Console.WriteLine(book.ToString());
                            }
                            break;
                        case 8:
                            Console.WriteLine("Enter language");
                            string language = Console.ReadLine();
                            filterService.filterByLanguage(language, listWorker.makeBooksList());
                            if (filterService.filterByLanguage(language, listWorker.makeBooksList()) == null)
                            {
                                Console.WriteLine("No books were found");
                            }
                            else
                            {
                                foreach (var book in filterService.filterByLanguage(language, listWorker.makeBooksList()))
                                    Console.WriteLine(book.ToString());
                            }
                            break;
                        case 9:
                            Console.WriteLine("Enter ISBN");
                            string isbnFilter = Console.ReadLine();
                            filterService.filterByISBN(isbnFilter, listWorker.makeBooksList());
                            if (filterService.filterByISBN(isbnFilter, listWorker.makeBooksList()) == null)
                            {
                                Console.WriteLine("No books were found");
                            }
                            else
                            {
                                foreach (var book in filterService.filterByISBN(isbnFilter, listWorker.makeBooksList()))
                                    Console.WriteLine(book.ToString());
                            }
                            break;
                        case 10:
                            Console.WriteLine("Enter book's name");
                            string name = Console.ReadLine();
                            filterService.filterByName(name, listWorker.makeBooksList());
                            if (filterService.filterByName(name, listWorker.makeBooksList()) == null)
                            {
                                Console.WriteLine("No books were found");
                            }
                            else
                            {
                                foreach (var book in filterService.filterByName(name, listWorker.makeBooksList()))
                                    Console.WriteLine(book.ToString());
                            }
                            break;
                        case 11:
                            filterService.filterTaken(listWorker.makeBooksList());
                            if (filterService.filterTaken(listWorker.makeBooksList()) == null)
                            {
                                Console.WriteLine("No books were found");
                            }
                            else
                            {
                                foreach (var book in filterService.filterTaken(listWorker.makeBooksList()))
                                    Console.WriteLine(book.ToString());
                            }
                            break;
                        case 12:
                            filterService.filterNotTaken(listWorker.makeBooksList());
                            if (filterService.filterNotTaken(listWorker.makeBooksList()) == null)
                            {
                                Console.WriteLine("No books were found");
                            }
                            else
                            {
                                foreach (var book in filterService.filterNotTaken(listWorker.makeBooksList()))
                                    Console.WriteLine(book.ToString());
                            }
                            break;
                        case 13:
                            logLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter a valid input...");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (FormatException)
                {
                    logLoop = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
               
            }

        }
    }
}
