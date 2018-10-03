using LibraryApp.BookRepositoryFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.ClientRepositoryFolder
{
    class Client
    {
        public string Name { get; set; }
        public List<Book> BooksBorrowed { get; set; }
    }
}
