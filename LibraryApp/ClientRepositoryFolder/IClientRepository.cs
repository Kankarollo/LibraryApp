using System.Collections.Generic;
using LibraryApp.BookRepositoryFolder;

namespace LibraryApp.ClientRepositoryFolder
{
    interface IClientRepository
    {
        void AddClient(string _name, Book _booksBorrowed);
        IEnumerable<Client> GetClients();
        void RemoveClient(string _name);
        void AddClientsBooks(string _name, Book _book);
        void RemoveClientsBooks(string _name, string _isbnNumber);
    }
}