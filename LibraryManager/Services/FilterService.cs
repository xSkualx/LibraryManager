using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LibraryManager
{
    public class FilterService
    {   
        public List<Book> showBooks(List<Book> books)
        {
            if (!books.Any())
            {
                return null;
            }
            else
            {
                return books;
            }
        }
        public List<Book> filterByAuthor(string author, List<Book> books)
        {
       
            var filterAuthor = books.Where(i => i.Author.Contains(author)).ToList();

            if (!filterAuthor.Any())
            {
                return null;
            }
            else
            {
                return filterAuthor;
            }
                 
        }
        public List<Book> filterByCategory(string category, List<Book> books)
        {
            var filterCategory = books.Where(i => i.Category.Contains(category)).ToList();

            if (!filterCategory.Any())
            {
                return null;
            }
            else
            {
                return filterCategory;
            }
        }
        public List<Book> filterByLanguage(string language, List<Book> books)
        {
            var filterLanguage = books.Where(i => i.Language.Contains(language)).ToList();
            if (!filterLanguage.Any())
            {
                return null;
            }
            else
            {
                return filterLanguage;
            }
        }
        public List<Book> filterByISBN(string isbn, List<Book> books)
        {
            var filterISBN = books.Where(i => i.ISBN.Contains(isbn)).ToList();
            if (!filterISBN.Any())
            {
                return null;
            }
            else
            {
                return filterISBN;
            }
        }
        public List<Book> filterByName(string name, List<Book> books)
        {
            var filterName = books.Where(i => i.Name.Contains(name)).ToList();
            if (!filterName.Any())
            {
                return null;
            }
            else
            {
                return filterName;
            }
        }
        public List<Book> filterTaken(List<Book> books)
        {
            var filtTaken = books.Where(i => i.BookStatus == Status.TAKEN).ToList();
            if (!filtTaken.Any())
            {
                return null;
            }
            else
            {
                return filtTaken;
            }
        }
        public List<Book> filterNotTaken(List<Book> books)
        {
            var filtNotTaken = books.Where(i => i.BookStatus == Status.NOT_TAKEN).ToList();
            if (!filtNotTaken.Any())
            {
                return null;
            }
            else
            {
                return filtNotTaken;
            }
        }
    }
}
