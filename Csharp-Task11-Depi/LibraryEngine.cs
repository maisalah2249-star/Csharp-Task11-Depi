using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Task11_Depi
{
    public delegate string BookDelegate(Book B);

    public class LibraryEngine
    {
        // User-defined delegate
        public static void ProcessBooks(
            List<Book> books,
            BookDelegate fPtr)
        {
            foreach (Book B in books)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        // Built-in Func delegate
        public static void ProcessBooksFunc(
            List<Book> books,
            Func<Book, string> fPtr)
        {
            foreach (Book B in books)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}
