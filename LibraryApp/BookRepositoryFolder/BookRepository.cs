﻿using System;
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
                ISBNnumber = "9913812395",
                borrower = "Jan Kowalski",
                lastBorrow = new DateTime(2018,1,15),
                borrowed = false
            },

             new Book
            {
                name = "Lord Of The Rings",
                author = "Tolkien",
                ISBNnumber = "2421512512",
                borrower = "Justyna",
                lastBorrow = new DateTime(2018,3,12),
                borrowed = false
            },
              new Book
            {
                name = "Krzyzacy",
                author = "Henryk Sienkiewicz",
                ISBNnumber = "3382501235",
                borrower = "Przemek",
                lastBorrow = new DateTime(2018,5,18),
                borrowed = false
            },
               new Book
            {
                name = "Potop",
                author = "Henryk Sienkiewicz",
                ISBNnumber = "4038519248",
                borrower = "Piotr",
                lastBorrow = new DateTime(2018,2,28),
                borrowed = true
            },
                new Book
            {
                name = "Opowiesci z Narnii",
                author = "C.S.Lewis",
                ISBNnumber = "5841501295",
                borrower = "Pawel",
                lastBorrow = new DateTime(2018,8,20),
                borrowed = false
            },
                 new Book
            {
                name = "Gra o Tron",
                author = "J.J.Martin",
                ISBNnumber = "6059215123",
                borrower = "Kacper",
                lastBorrow = new DateTime(2018,6,12),
                borrowed = false
            },
                 new Book
            {
                name = "Malowany Czlowiek",
                author = "Peter.V.Brett",
                ISBNnumber = "7851325123",
                borrower = "Marta",
                lastBorrow = new DateTime(2018,3,13),
                borrowed = false
            },
                  new Book
            {
                name = "Eragon",
                author = "Christopher Paolini",
                ISBNnumber = "8948215123",
                borrower = "Klaudia",
                lastBorrow = new DateTime(2018,4,10),
                borrowed = true
            },
                   new Book
            {
                name = "Dżuma",
                author = "Albert Camus",
                ISBNnumber = "9096868440",
                borrower = "Wiktoria",
                lastBorrow = new DateTime(2018,5,5),
                borrowed = false
            },
                    new Book
            {
                name = "Takorzecze Zaratustra",
                author = "Fryderyk Nietzsche",
                ISBNnumber = "1075312851",
                borrower = "Milosz",
                lastBorrow = new DateTime(2018,6,26),
                borrowed = true
            },
        };

        public IEnumerable<Book> GetBook()
        {
            return _bookRepository;
        }

        public void AddBooks()
        {
            Console.WriteLine("Podaj Tytul:");
            string _title = Console.ReadLine();
            Console.WriteLine("Podaj Autora:");
            string _author = Console.ReadLine();
            string _ISBNnumber;
            do {
                Console.WriteLine("Podaj numer ISBN:");

                 _ISBNnumber = Console.ReadLine();
            } while(_ISBNnumber.Length != 10);
            _bookRepository.Add(new Book
            {
                name = _title,
                author = _author,
                ISBNnumber = _ISBNnumber,
                borrowed = false
            });
            Console.WriteLine("Ksiazka zostala dodana do bazy danych.");
        }
        public void DeleteBooks()
        {
            Console.WriteLine("Podaj tytul lub numer ISBN ksiazki ktora chcesz usunac: ");
            Console.ReadLine();
        }
        public void BorrowBook()
        {
            Console.WriteLine("Podaj tytul lub numer ISBN ksiazki ktora chcesz wypozyczyc: ");
            Console.ReadLine();
        }
    }
}
