using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp.BookRepositoryFolder
{
    class BookRepositoryService
    {

        public static IEnumerable<Book> SearchForBook(IEnumerable<Book> _bookRepository)
        {
            Console.WriteLine("Podaj dokladnie autora, nazwe lub numer ISBN:");
            var keyWord = Console.ReadLine();
            if (_bookRepository.Any(x => x.name == keyWord || x.author == keyWord || x.ISBNnumber == keyWord))
            {
                return _bookRepository.Where(x => x.name == keyWord || x.author == keyWord || x.ISBNnumber == keyWord);
            }
            return null;
        }

        public static IEnumerable<Book> SearchForBooksInSpecificTime(IEnumerable<Book> _bookRepository)
        {
            Console.WriteLine("Podaj zakres tygodni, w ktorym szukasz ksiazek:");
            var searchWeeks = Console.ReadLine();
            if(Int32.TryParse(searchWeeks, out int result))
            {
                return _bookRepository.Where(x => x.lastBorrow == null || (DateTime.Today - x.lastBorrow).TotalDays / 7 <= result);
            }
            else
            {
                Console.WriteLine("Blednie podany zakres, pamietaj by podac tylko liczbe.");
                return SearchForBooksInSpecificTime(_bookRepository);
            }            
        }
        
        public static string BookInfo(IEnumerable<Book> _bookRepository)
        {
            if (_bookRepository == null) return "Nie ma takiej ksiazki w bazie danych.";
            StringBuilder bookInfo = new StringBuilder();
            foreach (var _book in _bookRepository)
            {
                bookInfo.AppendLine($"\nTytul: {_book.name}");
                bookInfo.AppendLine($"Autor: { _book.author}");
                bookInfo.AppendLine($"Numer ISBN: {_book.ISBNnumber}");
                bookInfo.AppendLine($"Ostatnio wypozyczona: {_book.lastBorrow.Date}");
                bookInfo.AppendLine($"Wypozyczone przez: {_book.borrower}");
                bookInfo.Append("Wypozyczone: "); if (_book.borrowed) bookInfo.AppendLine("Tak\n"); else bookInfo.AppendLine("Nie\n");
            }
            return bookInfo.ToString();
        }
    }
}
