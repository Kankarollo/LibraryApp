using System.Collections.Generic;

namespace LibraryApp.BookRepositoryFolder
{
    interface IBookRepository
    {
        void AddBooks();
        void BorrowBook();
        void DeleteBooks();
        IEnumerable<Book> GetBooks();
        void showBooks();
    }
}