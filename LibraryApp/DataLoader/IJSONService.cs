using System.Collections.Generic;
using LibraryApp.BookRepositoryFolder;

namespace LibraryApp.DataLoader
{
    interface IJSONService
    {
        List<Book> GetJsonList(string pathname);
        void SaveChangesToJsonFile(IEnumerable<Book> bookListToSave);
    }
}