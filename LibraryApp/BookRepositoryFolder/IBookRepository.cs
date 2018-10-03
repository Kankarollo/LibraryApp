using LibraryApp.ClientRepositoryFolder;
using System.Collections.Generic;

namespace LibraryApp.BookRepositoryFolder
{
    interface IBookRepository
    {
        IEnumerable<Book> GetBookRepo();
        void LoadBookRepository();
        void AddBooks();
        void DeleteBooks(IClientRepository _clientRepository);
        void BorrowBook(IClientRepository _clientRepository);
    }
}