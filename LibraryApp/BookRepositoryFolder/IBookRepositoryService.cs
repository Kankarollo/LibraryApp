using System.Collections.Generic;

namespace LibraryApp.BookRepositoryFolder
{
    interface IBookRepositoryService
    {
        string ClientsList();
        IEnumerable<Book> SearchForBook();
        string SearchForBooksInSpecificTime();
        string BookInfo(IEnumerable<Book> _book);
    }
}