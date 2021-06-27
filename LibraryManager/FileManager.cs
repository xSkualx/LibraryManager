using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryManager
{
    public class FileManager
    {
        private string booksFile = "books.json";
        private string borrowsFile = "borrows.json";

        public void manageFile()
        {
            string list = "[]";
            if (File.Exists(booksFile) && File.Exists(borrowsFile))
            {
                if (new FileInfo(booksFile).Length == 0)
                {
                    File.WriteAllText(booksFile, list);
                }
                if (new FileInfo(borrowsFile).Length == 0)
                {
                    File.WriteAllText(borrowsFile, list);
                }
            }
            else
            {
                Console.WriteLine("Files were not found");
                Environment.Exit(0);
            }
        }
    }
}
