using LibraryApp.ClientRepositoryFolder;
using LibraryApp.DataLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibraryApp.BookRepositoryFolder
{
    class BookRepository : IBookRepository
    {
        private readonly IJSONService _jsonService;
        private readonly IXMLService _xmlService;
        public string pathname;

        public BookRepository(IJSONService jsonService, IXMLService xmlService)
        {
            _xmlService = xmlService;
            _jsonService = jsonService;
            LoadBookRepository();
        }

        //private static List<Book> _bookRepository = new List<Book>
        //{
        //    new Book
        //    {
        //        name = "Harry Potter",
        //        author = "J.K Rowling",
        //        ISBNnumber = "9913812395",
        //        borrower = null,
        //        lastBorrow = new DateTime(2018,1,15),
        //        borrowed = false
        //    },

        //     new Book
        //    {
        //        name = "Lord Of The Rings",
        //        author = "Tolkien",
        //        ISBNnumber = "2421512512",
        //        borrower = null,
        //        lastBorrow = new DateTime(2018,3,12),
        //        borrowed = false
        //    },
        //      new Book
        //    {
        //        name = "Krzyzacy",
        //        author = "Henryk Sienkiewicz",
        //        ISBNnumber = "3382501235",
        //        borrower = null,
        //        lastBorrow = new DateTime(2018,5,18),
        //        borrowed = false
        //    },
        //       new Book
        //    {
        //        name = "Potop",
        //        author = "Henryk Sienkiewicz",
        //        ISBNnumber = "4038519248",
        //        borrower = "Piotr",
        //        lastBorrow = new DateTime(2018,2,28),
        //        borrowed = true
        //    },
        //        new Book
        //    {
        //        name = "Opowiesci z Narnii",
        //        author = "C.S.Lewis",
        //        ISBNnumber = "5841501295",
        //        borrower = null,
        //        lastBorrow = new DateTime(2018,8,20),
        //        borrowed = false
        //    },
        //         new Book
        //    {
        //        name = "Gra o Tron",
        //        author = "J.J.Martin",
        //        ISBNnumber = "6059215123",
        //        borrower = null,
        //        lastBorrow = new DateTime(2018,6,12),
        //        borrowed = false
        //    },
        //         new Book
        //    {
        //        name = "Malowany Czlowiek",
        //        author = "Peter.V.Brett",
        //        ISBNnumber = "7851325123",
        //        borrower = null,
        //        lastBorrow = new DateTime(2018,3,13),
        //        borrowed = false
        //    },
        //          new Book
        //    {
        //        name = "Eragon",
        //        author = "Christopher Paolini",
        //        ISBNnumber = "8948215123",
        //        borrower = "Klaudia",
        //        lastBorrow = new DateTime(2018,4,10),
        //        borrowed = true
        //    },
        //           new Book
        //    {
        //        name = "Dżuma",
        //        author = "Albert Camus",
        //        ISBNnumber = "9096868440",
        //        borrower = null,
        //        lastBorrow = new DateTime(2018,5,5),
        //        borrowed = false
        //    },
        //            new Book
        //    {
        //        name = "Takorzecze Zaratustra",
        //        author = "Fryderyk Nietzsche",
        //        ISBNnumber = "1075312851",
        //        borrower = "Milosz",
        //        lastBorrow = new DateTime(2018,6,26),
        //        borrowed = true
        //    },
        //};

        private static List<Book> _bookRepository = new List<Book>();

        public IEnumerable<Book> GetBookRepo()
        {
            return _bookRepository;
        }

        public void LoadBookRepository()
        {
            Console.WriteLine("Podaj dokladnie nazwe pliku z danymi. Plik musi miescic sie w folderze DataFiles w projekcie:");
            pathname = Console.ReadLine();
            var extension = Path.GetExtension(pathname);
            if (extension == ".xml")
            {
                var xmlData = _xmlService.LoadXmlDataFromFile(pathname);
                _bookRepository = _xmlService.ExtractBookDataFromXmlData(xmlData);
            }
            else if(extension == ".json")
            {
                _bookRepository = _jsonService.ConvertJsonToList(pathname);
            }
            else
            {
                Console.WriteLine("Brak pliku spelniajacego wymagania.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void AddBooks()
        {
            Console.WriteLine("Podaj Tytul:");
            string _title = Console.ReadLine();
            Console.WriteLine("Podaj Autora:");
            string _author = Console.ReadLine();
            string _ISBNnumber;
            do {
                Console.WriteLine("Podaj 10-cyfrowy numer ISBN:");
              _ISBNnumber = Console.ReadLine();
            } while(_ISBNnumber.Length != 10);
            _bookRepository.Add(new Book
            {
                name = _title,
                author = _author,
                ISBNnumber = _ISBNnumber,
                borrower = "",
                borrowed = false
            });
            Console.WriteLine("Ksiazka zostala dodana do bazy danych.");
            BookRepositoryService.SaveChangesToFile(_jsonService, _xmlService, pathname, _bookRepository);
        }

        public void DeleteBooks(IClientRepository _clientRepository)
        {
            var booksToDelete = BookRepositoryService.SearchForBook(GetBookRepo());
            Console.WriteLine(BookRepositoryService.BookInfo(booksToDelete));
            Console.WriteLine("Aby potwierdzic napisz numer ISBN ksiazki ktora chcesz usunac z bazy danych. UWAGA: Zmiany beda permanentne.");
            var numberISBNOfBookToDelete = Console.ReadLine();
            foreach (var client in _clientRepository.GetClients())
            {
                _clientRepository.RemoveClientsBooks(client.Name, numberISBNOfBookToDelete);
            }
            _bookRepository.RemoveAll(x => x.ISBNnumber == numberISBNOfBookToDelete);
            Console.WriteLine("Ksiazka zostala usunieta z bazy danych.");
            BookRepositoryService.SaveChangesToFile(_jsonService, _xmlService, pathname, _bookRepository);
        }

        public void BorrowBook(IClientRepository _clientRepository)
        {
            Console.WriteLine("Podaj tytul lub numer ISBN ksiazki ktora chcesz wypozyczyc: ");
            var keyWord = Console.ReadLine();
            Book toBorrow = _bookRepository.Find(x => x.name == keyWord || x.ISBNnumber == keyWord);
            Console.WriteLine("Czy chodzilo ci o ksiazke...: ");
            Console.WriteLine(BookRepositoryService.BookInfo(_bookRepository.Where(x => x.name == keyWord || x.ISBNnumber == keyWord)));
            Console.WriteLine("Jesli nie wcisnij  'q' by anulowac.");
            if (Console.ReadLine() == "q") return;
            Console.WriteLine("Prosze podac imie i nazwisko.");
            var borrower = Console.ReadLine();
            if (!toBorrow.borrowed)
            {
                toBorrow.borrower = borrower;
                toBorrow.borrowed = true;
                toBorrow.lastBorrow = DateTime.Today;
                _clientRepository.AddClientsBooks(borrower, toBorrow);
            }
            else
            {
                Console.WriteLine("Niestety ksiazka zostala wypozyczona "
                    + toBorrow.lastBorrow);
                return;
            }
            Console.WriteLine("Ksiazka zostala wypozyczona do " + toBorrow.lastBorrow.AddMonths(1));
            BookRepositoryService.SaveChangesToFile(_jsonService, _xmlService, pathname, _bookRepository);
        }

    }
}
