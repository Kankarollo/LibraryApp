using System;
using System.Collections.Generic;
using System.Xml.Linq;
using LibraryApp.BookRepositoryFolder;

namespace LibraryApp.DataLoader
{
    interface IXMLService
    {
        List<Book> ExtractBookDataFromXmlData(IEnumerable<XElement> xmlData);
        IEnumerable<XElement> LoadXmlDataFromFile(string pathname);
        void SaveChangesToXmlFile(List<Book> _bookRepository);
    }
}