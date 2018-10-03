using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp.BookRepositoryFolder
{
    abstract class BookFound
    {
        public abstract IEnumerable<Book> Books(IEnumerable<Book> _bookRepository);
    }

    class BookFoundByName : BookFound
    {
        public override IEnumerable<Book> Books(IEnumerable<Book> _bookRepository)
        {
            Console.WriteLine("Podaj dokladnie autora, nazwe lub numer ISBN:");
            var keyWord = Console.ReadLine();
            if (_bookRepository.Any(x => x.name == keyWord || x.author == keyWord || x.ISBNnumber == keyWord))
            {
                return _bookRepository.Where(x => x.name == keyWord || x.author == keyWord || x.ISBNnumber == keyWord);
            }
            else
            {
                Console.WriteLine("Brak ksiazki o takich danych!");
                return Books(_bookRepository);
            }
        }
    }

    class BookFoundByTime : BookFound
    {
        public override IEnumerable<Book> Books(IEnumerable<Book> _bookRepository)
        {
            Console.WriteLine("Podaj zakres tygodni, w ktorym szukasz ksiazek:");
            var searchWeeks = Console.ReadLine();
            if (Int32.TryParse(searchWeeks, out int result))
            {
                return _bookRepository.Where(x => x.lastBorrow == null || (DateTime.Today - x.lastBorrow).TotalDays / 7 <= result);
            }
            else
            {
                Console.WriteLine("Blednie podany zakres, pamietaj by podac tylko liczbe.");
                return Books(_bookRepository);
            }
        }
    }
}
