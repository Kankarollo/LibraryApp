using System;
using System.Collections.Generic;
using System.Text;
using LibraryApp.BookRepositoryFolder;
using LibraryApp.ClientRepositoryFolder;

namespace LibraryApp.MenuFolder
{
    class Menu : IMenu
    {
        private readonly IBookRepository _bookRepository;
        private readonly IClientRepository _clientRepository;

        private bool exit = false;
        public Dictionary<int, string> MenuDictionary()
        {
            Dictionary<int, string> _menuList = new Dictionary<int, string>
            {
                { 1, "Dodanie ksiazki." },
                { 2, "Usuniecie ksiazki z katalogu." },
                { 3, "Wyszukiwanie ksiazki po nazwie autorze lub numerze ISBN." },
                { 4, "Wyszukanie książek, które nie zostały wypożyczone przez ostatnie x tygodni." },
                { 5, "Wypozyczenie ksiazki (trzeba podac imie i nazwisko wypozyczajacego)." },
                { 6, "Wyswietlenie listy ludzi, ktorzy aktualnie maja wypozyczona" +
                " jakakolwiek ksiazke wraz z iloscia wypozyczonych ksiazek (np.Jan Kowalski:10 ksiazek)" },
                { 7, "Wyswietl liste wszystkich ksiazek" }
            };

            return _menuList;
        }
        public string MenuList()
        {
            var _menulist = MenuDictionary();
            StringBuilder menu = new StringBuilder();
            menu.Append("LibraryApp v1.0\n");
            menu.Append("---------------------------------\n");
            foreach(var command in _menulist)
            {
                menu.Append($"{command.Key.ToString()}. {command.Value}\n");
            }
            menu.Append("Q. Exit Program");

            return menu.ToString();
        }

        public Menu(IBookRepository bookRepository, IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _bookRepository = bookRepository;
        }

        public void ShowMenuUntilStoppedAndOperateCommands()
        {
            while (!exit)
            {
                System.Console.Clear();
                Console.WriteLine(MenuList());
                var command = Console.ReadLine();
                this.ExecuteCommandOrExit(command);
            }
        }

        public void ExecuteCommandOrExit(string command)
        {
            switch (command.ToUpper())
            {
                case "1":
                    _bookRepository.AddBooks();
                    break;
                case "2":
                    _bookRepository.DeleteBooks(_clientRepository);
                    break;
                case "3":
                    ShowListOfBooks(SearchBy.ByName);
                    break;
                case "4":
                    ShowListOfBooks(SearchBy.ByTime);
                    break;
                case "5":
                    _bookRepository.BorrowBook(_clientRepository);
                    break;
                case "6":
                    ShowClientsList();
                    break;
                case "7":
                    ShowAllBooks();
                    break;
                case "Q":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Wrong Command!");
                    break;
            }
            Console.WriteLine("Powrot");
            Console.ReadLine();
        }

        public void ShowListOfBooks(SearchBy searchBy)
        {
            BookFound booksFound = null;
            switch (searchBy)
            {
                case SearchBy.ByName:
                    booksFound = new BookFoundByName();
                    break;
                case SearchBy.ByTime:
                    booksFound = new BookFoundByTime();
                    break;
                default:
                    break;
            }
            IEnumerable<Book> books = booksFound.Books(_bookRepository.GetBookRepo());
            string bookinfo = BookRepositoryService.BookInfo(books);
            Console.WriteLine(bookinfo);
        }

        public void ShowAllBooks()
        {
            var books = _bookRepository.GetBookRepo();
            var booksInfo = BookRepositoryService.BookInfo(books);
            Console.WriteLine(booksInfo);
        }

        public void ShowClientsList()
        {
            StringBuilder clientList = new StringBuilder();
            var clients = _clientRepository.GetClients();
            foreach (var client in clients)
            {
                clientList.AppendLine($"\nImie i nazwisko klienta: {client.Name}");
                clientList.AppendLine($"Wypozyczone ksiazki: {client.BooksBorrowed.Count}");
                foreach (var book in client.BooksBorrowed)
                    clientList.AppendLine($"Nazwa: {book.name}, nr ISBN {book.ISBNnumber}");
            }
            Console.WriteLine(clientList.ToString());  
        }
    }
}
