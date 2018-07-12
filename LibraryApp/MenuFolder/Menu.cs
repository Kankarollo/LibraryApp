using System;
using System.Collections.Generic;
using System.Text;
using LibraryApp.BookRepositoryFolder;


namespace LibraryApp.MenuFolder
{
    class Menu : IMenu
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookRepositoryService _bookRepositoryService;

        public Menu(IBookRepository bookRepository, IBookRepositoryService bookRepositoryService)
        {
            _bookRepositoryService = bookRepositoryService;
            _bookRepository = bookRepository;
        }
        public Dictionary<int , string> MenuList()
        {
            Dictionary<int, string> _menuList = new Dictionary<int, string>
            {
                { 1, "Dodanie ksiazki." },
                { 2, "Usuniecie ksiazki z katalogu." },
                { 3, "Wyszukiwanie ksiazki po nazwie autorze lub numerze ISBN." },
                { 4, $"Wyszukanie książek, które nie zostały wypożyczone przez ostatnie x tygodni." },
                { 5, "Wypozyczenie ksiazki (trzeba podac imie i nazwisko wypozyczajacego)." },
                {
                    6,
                    "Wyswietlenie listy ludzi, ktorzy aktualnie maja wypozyczona" +
                " jakakolwiek ksiazke wraz z iloscia wypozyczonych ksiazek (np.Jan Kowalski:10 ksiazek)"
                },
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
                    break;
                case "3":
                    Console.WriteLine(_bookRepositoryService.BookInfo(_bookRepositoryService.SearchForBook()));
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    Console.WriteLine(_bookRepositoryService.BookInfo(_bookRepository.GetBook())); 
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
