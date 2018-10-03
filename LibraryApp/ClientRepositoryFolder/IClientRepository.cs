using System.Collections.Generic;
using LibraryApp.BookRepositoryFolder;

namespace LibraryApp.ClientRepositoryFolder
{
    interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        bool IsClientExist(string keyName);
        void AddClient(string _name, Book _booksBorrowed);
        void RemoveClient(string _name);
        void AddClientsBooks(string _name, Book _book);
        void RemoveClientsBooks(string _name, string _isbnNumber);
    }
}