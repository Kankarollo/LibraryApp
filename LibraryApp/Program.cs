using System;
using LibraryApp.BookRepositoryFolder;
using LibraryApp.MenuFolder;

namespace LibraryApp
{
    class Program
    {

        private static readonly BookRepository bookRepository = new BookRepository(menu);
        private static readonly Menu menu = new Menu(bookRepository);


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in library system LibraryApp v1.0");
            menu.ShowMenu();
        }
    }
}
