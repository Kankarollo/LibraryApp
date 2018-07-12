using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp.BookRepositoryFolder
{
    class BookRepositoryService : IBookRepositoryService
    {
        private readonly IBookRepository _bookRepository;
        public BookRepositoryService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> SearchForBook()
        {
            Console.WriteLine("Podaj dokladnie autora, nazwe lub numer ISBN:");
            string keyWord = Console.ReadLine();
            if (_bookRepository.GetBook().Any(x => x.name == keyWord || x.author == keyWord || x.ISBNnumber == keyWord))
            {
                return _bookRepository.GetBook().Where(x => x.name == keyWord || x.author == keyWord || x.ISBNnumber == keyWord);
            }
            return null;
        }
        public string SearchForBooksInSpecificTime()
        {

            return "Hello";
        }

        public string ClientsList()
        {
            return "Hello";
        }

        public string BookInfo(IEnumerable<Book> book)
        {
            if (book == null) return "Nie ma takiej ksiazki w bazie danych.";
            StringBuilder bookInfo = new StringBuilder();
            foreach (var _book in book)
            {
                bookInfo.AppendLine("\nTytul: " + _book.name);
                bookInfo.AppendLine("Autor: " + _book.author);
                bookInfo.AppendLine("Numer ISBN: " + _book.ISBNnumber);
                bookInfo.AppendLine("Ostatnio wypozyczona: " + _book.lastBorrow.Date);
                bookInfo.AppendLine("Wypozyczone przez: " + _book.borrower);
                bookInfo.Append("Wypozyczone: "); if (_book.borrowed) bookInfo.AppendLine("Tak\n"); else bookInfo.AppendLine("Nie\n");
            }
            return bookInfo.ToString();
        }
    }
}
