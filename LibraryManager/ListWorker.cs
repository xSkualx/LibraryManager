using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace LibraryManager
{
    public class ListWorker
    {
        private string booksFile = "books.json";
        private string borrowsFile = "borrows.json";
        public List<Book> makeBooksList()
        {
            List<Book> books = new List<Book>();
            string jsonString = File.ReadAllText(booksFile);
            books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            return books;
        }
        public List<BorrowDetails> makeBorrowsList()
        {
            List<BorrowDetails> borrowDetails = new List<BorrowDetails>();
            string jsonString = File.ReadAllText(borrowsFile);
            borrowDetails = JsonSerializer.Deserialize<List<BorrowDetails>>(jsonString);
            return borrowDetails;
        }
        public void writeBooksList(List<Book> books)
        {
            string jsonString = JsonSerializer.Serialize(books);
            File.WriteAllText(booksFile, jsonString);
        }
        public void writeBorrowsList(List<BorrowDetails> borrowDetails)
        {
            string jsonString = JsonSerializer.Serialize(borrowDetails);
            File.WriteAllText(borrowsFile, jsonString);
        }
    }
}
