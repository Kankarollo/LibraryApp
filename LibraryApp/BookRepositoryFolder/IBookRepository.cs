using LibraryApp.ClientRepositoryFolder;
using System.Collections.Generic;

namespace LibraryApp.BookRepositoryFolder
{
    interface IBookRepository
    {
        void AddBooks();
        void BorrowBook(IClientRepository _clientRepository);
        void DeleteBooks(IClientRepository _clientRepository);
        IEnumerable<Book> GetBookRepo();
    }
}