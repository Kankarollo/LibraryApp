using LibraryApp.BookRepositoryFolder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryApp.ClientRepositoryFolder
{
    class ClientRepository : IClientRepository
    {
        private List<Client> _clientRepository = new List<Client>();

        public ClientRepository(IBookRepository _bookRepository)
        {
            foreach (var book in _bookRepository.GetBookRepo())
            {
                if (book.borrowed)
                {
                    var _name = book.borrower;
                    if (GetClients().Any(x => x.Name == _name))
                        AddClientsBooks(_name, book);
                    else
                        AddClient(_name, book);
                }
            }
        }
        public IEnumerable<Client> GetClients()
        {
            return _clientRepository;
        }

        public bool IsClientExist(string keyName)
        {
            return _clientRepository.Any(x => x.Name == keyName);
        }

        public void AddClient(string _name, Book _booksBorrowed)
        {
            _clientRepository.Add(new Client { Name = _name, BooksBorrowed = new List<Book> {_booksBorrowed } } );
        }

        public void AddClientsBooks(string _name, Book _book)
        {
           var client = _clientRepository.Find(x => x.Name == _name);
           client.BooksBorrowed.Add(_book);
        }

        public void RemoveClientsBooks(string _name, string _isbnNumber)
        {
            var client = _clientRepository.Find(x => x.Name == _name);
            client.BooksBorrowed.RemoveAll(x => x.ISBNnumber == _isbnNumber);
        }

        public void RemoveClient(string _name)
        {
            _clientRepository.RemoveAll(x => x.Name == _name);
        }


    }
}
