using LibraryApp.BookRepositoryFolder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryApp.ClientRepositoryFolder
{
    class ClientRepositoryMaker
    {
       
        public static void  MakeClientRepository(IClientRepository _clientRepository, IBookRepository _bookRepository)
        {
            foreach (var book in _bookRepository.GetBookRepo())
            {
                if (book.borrowed)
                {
                    var _name = book.borrower;
                    if (_clientRepository.GetClients().Any(x => x.Name == _name)) _clientRepository.AddClientsBooks(_name, book);
                    else _clientRepository.AddClient(_name, book);
                }
            }
        }

        public static void Updater(IClientRepository _clientRepository)
        {
            
        }

        public static string ClientListReader(IClientRepository _clientRepository)
        {
            StringBuilder _clientList = new StringBuilder();
            var clients = _clientRepository.GetClients();
            foreach (var client in clients)
            {
                _clientList.AppendLine($"\nImie i nazwisko klienta: {client.Name}");
                _clientList.AppendLine($"Wypozyczone ksiazki: {client.BooksBorrowed.Count()}");
                foreach (var book in client.BooksBorrowed)
                    _clientList.AppendLine($"Nazwa: {book.name}, nr ISBN {book.ISBNnumber}");
            }
            return _clientList.ToString();
        }
    }
}
