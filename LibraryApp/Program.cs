using System;
using LibraryApp.BookRepositoryFolder;
using LibraryApp.ClientRepositoryFolder;
using LibraryApp.DataLoader;
using LibraryApp.MenuFolder;

namespace LibraryApp
{
    class Program
    {

        private static readonly BookRepository bookRepository = new BookRepository();
        private static readonly ClientRepository clientRepository = new ClientRepository();
        private static readonly Menu menu = new Menu(bookRepository, clientRepository);


        static void Main(string[] args)
        {
            ClientRepositoryMaker.MakeClientRepository(clientRepository, bookRepository);
            Console.WriteLine("Welcome in library system LibraryApp v1.0");
            XMLLoader.Test();
            //menu.ShowMenu();
        }
    }
}
