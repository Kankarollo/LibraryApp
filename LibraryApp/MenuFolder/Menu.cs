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

        public Menu(IBookRepository bookRepository, IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _bookRepository = bookRepository;
        }
        public Dictionary<int , string> MenuList()
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

        public string MenuListWriter()
        {
            var _menulist = MenuList();
            StringBuilder menu = new StringBuilder();
            menu.Append("---------------------------------\n");
            foreach(var command in _menulist)
            {
                menu.Append($"{command.Key.ToString()}. {command.Value}\n");
            }
            menu.Append("Q. Exit Program");

            return menu.ToString();
        }

        public void ShowMenu()
        {
            Console.WriteLine(MenuListWriter());
            var input = Console.ReadLine();
            switch (input.ToUpper())
            {
                case "1":
                    _bookRepository.AddBooks();
                    break;
                case "2":
                    _bookRepository.DeleteBooks(_clientRepository);
                    break;
                case "3":
                    Console.WriteLine(BookRepositoryService.BookInfo(BookRepositoryService.SearchForBook(_bookRepository.GetBookRepo())));
                    break;
                case "4":
                    Console.WriteLine(BookRepositoryService.BookInfo(BookRepositoryService.SearchForBooksInSpecificTime(_bookRepository.GetBookRepo())));
                    break;
                case "5":
                    _bookRepository.BorrowBook(_clientRepository);
                    break;
                case "6":
                    Console.WriteLine(ClientRepositoryMaker.ClientListReader(_clientRepository));
                    break;
                case "7":
                    Console.WriteLine(BookRepositoryService.BookInfo(_bookRepository.GetBookRepo())); 
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong Command!");
                    break;
            }
            Console.WriteLine("Powrot");
            Console.ReadLine();
            ShowMenu();
        }
    }
}
