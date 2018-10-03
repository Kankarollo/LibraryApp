using LibraryApp.DataLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibraryApp.BookRepositoryFolder
{
    class BookRepositoryService
    {
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
        public static string BookInfo(Book _book)
        {
            if (_book == null) return "Nie ma takiej ksiazki w bazie danych.";
            StringBuilder bookInfo = new StringBuilder();
            bookInfo.AppendLine($"\nTytul: {_book.name}");
            bookInfo.AppendLine($"Autor: { _book.author}");
            bookInfo.AppendLine($"Numer ISBN: {_book.ISBNnumber}");
            bookInfo.AppendLine($"Ostatnio wypozyczona: {_book.lastBorrow.Date}");
            bookInfo.AppendLine($"Wypozyczone przez: {_book.borrower}");
            bookInfo.Append("Wypozyczone: "); if (_book.borrowed) bookInfo.AppendLine("Tak\n"); else bookInfo.AppendLine("Nie\n");
            
            return bookInfo.ToString();
        }

        public static void SaveChangesToFile(IJSONService _jsonService, IXMLService _xmlService, string pathname, List<Book> _bookRepository)
        {
            if(Path.GetExtension(pathname) == ".xml")
            {
                _xmlService.SaveChangesToXmlFile(_bookRepository);
            }
            else if(Path.GetExtension(pathname) == ".json")
            {
                _jsonService.SaveChangesToJsonFile(_bookRepository);
            }
        }
    }
}
