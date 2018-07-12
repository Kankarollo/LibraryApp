using System.Collections.Generic;
using System.Text;
using LibraryApp.BookRepositoryFolder;


namespace LibraryApp.MenuFolder
{
    class Menu : IMenu
    {
        private readonly IBookRepository _bookRepository;

        public Menu(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Dictionary<int , string> MenuList()
        {
            Dictionary<int,string> _menuList = new Dictionary<int, string>();

            int weeks = 5;                                  // Jakoś inaczej to zrobic
            _menuList.Add(1, "Dodanie ksiazki.");
            _menuList.Add(2, "Usuniecie ksiazki z katalogu.");
            _menuList.Add(3, "Wyszukiwanie ksiazki po nazwie autorze lub numerze ISBN.");
            _menuList.Add(4, $"Wyszukanie książek, które nie zostały wypożyczone przez ostatnie {weeks} tygodnie.");
            _menuList.Add(5, "Wypozyczenie ksiazki (trzeba podac imie i nazwisko wypozyczajacego).");
            _menuList.Add(6, "Wyswietlenie listy ludzi, ktorzy aktualnie maja wypozyczona" +
                " jakakolwiek ksiazke wraz z iloscia wypozyczonych ksiazek (np.Jan Kowalski:10 ksiazek)");
            _menuList.Add(7, "Wyswietl liste wszystkich ksiazek");

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
            menu.Append("\nQ. Exit Program");

            return menu.ToString();
        }

        public void showMenu()
        {
            System.Console.WriteLine(MenuListWriter());
            var input = System.Console.ReadLine();
            switch (input.ToUpper())
            {
                case "1":
                    _bookRepository.AddBooks();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    _bookRepository.showBooks();
                    break;
                case "Q":
                    System.Environment.Exit(0);
                    break;
                default:
                    System.Console.WriteLine("Wrong Command!");
                    break;
            }
        }
    }
}
