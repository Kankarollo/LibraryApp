using LibraryApp.BookRepositoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace LibraryApp.DataLoader
{
    class XMLLoader
    {
        public IEnumerable<XElement> LoadXmlDataFromFile()
        {
            XmlDocument file = new XmlDocument();
            try
            {
                file.Load("DataFiles/xmlFile.xml");
                string xmlContent = file.InnerXml;
                var xmlElements = XDocument.Parse(xmlContent);
                var dataOfBooks = xmlElements.Elements("Book");
                return dataOfBooks;
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found!");
                return null;
            }
        }

        public List<Book> ExtractBookDataFromXmlData(IEnumerable<XElement> xmlData)
        {
            List<Book> listOfBooks = new List<Book>();
            foreach (var bookElement in xmlData)
            {
                var _name = bookElement.Element("title").Value;
                var _author = bookElement.Element("author").Value;
                var _ISBNnumber = bookElement.Element("ISBN").Value;
                //var _lastBorrow = bookElement.Element("lastBorrow").Value;
                var _borrower = bookElement.Element("borrower").Value;
                //var _borrowed = bookElement.Element("borrowed").Value; 
                listOfBooks.Add(new Book
                {
                    name =  _name,
                    author = _author,
                    ISBNnumber = _ISBNnumber,
                    //lastBorrow = _lastBorrow,
                    borrower = _borrower,
                    //borrowed = _borrowed 
                });
            }
            return listOfBooks;
        }

        public static void Test()
        {
            List<Book> testList = new List<Book>();
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load("xmlFidsadle.xml");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            string xmlcontents = doc.InnerXml;
            var elements = XElement.Parse(xmlcontents);
            var valueofElements = elements.Elements("Book");
            foreach (var element in valueofElements)
            {
                testList.Add(new Book
                {
                    name = element.Element("title").Value,
                    author = element.Element("author").Value,
                    ISBNnumber = element.Element("ISBN").Value,
                    //lastBorrow = element.Element("lastBorrow").Value
                    borrower = element.Element("borrower").Value,
                    //borrowed = element.Element("borrowed").Value, 
                });
            }
            foreach (var book in testList)
            {
                Console.WriteLine(book.name);
                Console.WriteLine(book.author);
                Console.WriteLine(book.ISBNnumber);
                Console.WriteLine(book.lastBorrow);
                Console.WriteLine(book.borrower);
                Console.WriteLine(book.borrowed);
            }

            Console.ReadKey();
        }

        
    }
}
