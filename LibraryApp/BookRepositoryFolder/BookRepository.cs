using System;
using System.Collections.Generic;
using System.Text;
using LibraryApp.MenuFolder;

namespace LibraryApp.BookRepositoryFolder
{
    class BookRepository : IBookRepository
    {
        private readonly IMenu _menu;
        public BookRepository(IMenu menu)
        {
            _menu = menu;
        }

        private static List<Book> _bookRepository = new List<Book>
        {
            new Book
            {
                name = "Harry Potter",
                author = "J.K Rowling",
                ISBNnumber = 1,
                borrower = "Jan Kowalski",
                lastBorrow = new DateTime(2018,1,15),
                borrowed = false
            },

             new Book
            {
                name = "Lord Of The Rings",
                author = "Tolkien",
                ISBNnumber = 2,
                borrower = "Justyna",
                lastBorrow = new DateTime(2018,3,12),
                borrowed = false
            },
              new Book
            {
                name = "Krzyzacy",
                author = "Henryk Sienkiewicz",
                ISBNnumber = 3,
                borrower = "Przemek",
                lastBorrow = new DateTime(2018,5,18),
                borrowed = false
            },
               new Book
            {
                name = "Potop",
                author = "Henryk Sienkiewicz",
                ISBNnumber = 4,
                borrower = "Piotr",
                lastBorrow = new DateTime(2018,2,28),
                borrowed = true
            },
                new Book
            {
                name = "Opowiesci z Narnii",
                author = "C.S.Lewis",
                ISBNnumber = 5,
                borrower = "Pawel",
                lastBorrow = new DateTime(2018,8,20),
                borrowed = false
            },
                 new Book
            {
                name = "Gra o Tron",
                author = "J.J.Martin",
                ISBNnumber = 6,
                borrower = "Kacper",
                lastBorrow = new DateTime(2018,6,12),
                borrowed = false
            },
                 new Book
            {
                name = "Malowany Czlowiek",
                author = "Peter.V.Brett",
                ISBNnumber = 7,
                borrower = "Marta",
                lastBorrow = new DateTime(2018,3,13),
                borrowed = false
            },
                  new Book
            {
                name = "Eragon",
                author = "Christopher Paolini",
                ISBNnumber = 8,
                borrower = "Klaudia",
                lastBorrow = new DateTime(2018,4,10),
                borrowed = true
            },
                   new Book
            {
                name = "Dżuma",
                author = "Albert Camus",
                ISBNnumber = 9,
                borrower = "Wiktoria",
                lastBorrow = new DateTime(2018,5,5),
                borrowed = false
            },
                    new Book
            {
                name = "Takorzecze Zaratustra",
                author = "Fryderyk Nietzsche",
                ISBNnumber = 10,
                borrower = "Milosz",
                lastBorrow = new DateTime(2018,6,26),
                borrowed = true
            },
        };

        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository;
        }
        public void AddBooks()
        {
            Console.WriteLine("Podaj Tytul:");
            string _title = Console.ReadLine();
            Console.WriteLine("Podaj Autora:");
            string _author = Console.ReadLine();
            Console.WriteLine("Podaj numer ISBN:");
            int _ISBNnumber = Int16.Parse(Console.ReadLine());

            _bookRepository.Add(new Book
            {
                name = _title,
                author = _author,
                ISBNnumber = _ISBNnumber,
                borrowed = false
            });

            _menu.MenuListWriter();

        }
        public void DeleteBooks()
        {

        }
        public void BorrowBook()
        {

        }

        public void showBooks()
        {
            foreach (var book in _bookRepository){
                Console.WriteLine("Tytul: " + book.name);
                Console.WriteLine("Autor: " + book.author);
                Console.WriteLine("Numer ISBN: " + book.ISBNnumber);
                Console.WriteLine("Ostatnio wypozyczona: " + book.lastBorrow);
                Console.WriteLine("Wypozyczone przez: " + book.borrower);
                // Console.WriteLine("Wypozyczone: " + book.name);
                Console.WriteLine("\n");
            }

            _menu.MenuListWriter();

        }




    }
}
