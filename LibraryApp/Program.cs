using System;
using LibraryApp.BookRepositoryFolder;
using LibraryApp.ClientRepositoryFolder;
using LibraryApp.DataLoader;
using LibraryApp.MenuFolder;

namespace LibraryApp
{
    class Program
    {
        private static readonly JSONService jsonService = new JSONService();
        private static readonly XMLService xmlService = new XMLService();
        private static readonly BookRepository bookRepository = new BookRepository(jsonService, xmlService);
        private static readonly ClientRepository clientRepository = new ClientRepository(bookRepository);
        private static readonly Menu menu = new Menu(bookRepository, clientRepository);


        static void Main(string[] args)
        {
            System.Console.Clear();
            Console.WriteLine("Welcome in library system LibraryApp v1.0");
            Console.ReadKey();
            menu.ShowMenuUntilStoppedAndOperateCommands();
        }
    }
}
