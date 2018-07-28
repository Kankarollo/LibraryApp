using LibraryApp.BookRepositoryFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LibraryApp.DataLoader
{
    class XMLService : IXMLService
    {
        private string PathToFile;

        public IEnumerable<XElement> LoadXmlDataFromFile(string pathname)
        {
            PathToFile = "DataFiles/" + pathname;
            XmlDocument file = new XmlDocument();
            try
            {
                file.Load(PathToFile);
                string xmlContent = file.InnerXml;
                var xmlElements = XElement.Parse(xmlContent);
                var _valueofelements =  xmlElements.Elements("Book");
                return _valueofelements;
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found!");
                Environment.Exit(0);
                return null;
            }
        }

        public List<Book> ExtractBookDataFromXmlData(IEnumerable<XElement> xmlData)
        {
            List<Book> listOfBooks = new List<Book>();
            foreach (var bookElement in xmlData)
            {
                var _name = bookElement.Element("name").Value;
                var _author = bookElement.Element("author").Value;
                var _ISBNnumber = bookElement.Element("ISBNnumber").Value;
               // var _lastBorrow = MakeDateFromXmlData(bookElement.Element("lastBorrow"));
                var _borrower = bookElement.Element("borrower").Value;
                var _borrowed = Boolean.Parse(bookElement.Element("borrowed").Value);
                

                listOfBooks.Add(new Book
                {
                    name =  _name,
                    author = _author,
                    ISBNnumber = _ISBNnumber,
                   // lastBorrow = _lastBorrow,
                    borrower = _borrower,
                    borrowed = _borrowed 
                });
            }
            return listOfBooks;
        }

        public DateTime MakeDateFromXmlData(XElement dateElement)
        {
            Int32.TryParse(dateElement.Element("day").Value, out int day);
            Int32.TryParse(dateElement.Element("month").Value, out int month);
            Int32.TryParse(dateElement.Element("year").Value, out int year);
            return new DateTime(year,month,day);
        }

        public void SaveChangesToXmlFile(List<Book> _bookRepository)
        {
                XmlSerializer _xmlSerializer = new XmlSerializer(typeof(List<Book>));
                var xmlData = "";
                using (var _stringWriter = new Utf8StringWriter())
                {
                    using (XmlWriter _xmlWriter = XmlWriter.Create(_stringWriter))
                    {
                        _xmlSerializer.Serialize(_xmlWriter, _bookRepository);
                        xmlData = _stringWriter.ToString();
                        File.WriteAllText(PathToFile, xmlData);
                    }
                }
        }

        //public static void Test()
        //{
        //    List<Book> testList = new List<Book>();
        //    XmlDocument doc = new XmlDocument();
        //    try
        //    {
        //        doc.Load("DataFiles/xmlFile.xml");
        //    }
        //    catch (System.IO.FileNotFoundException)
        //    {
        //        Console.WriteLine("File not found!");
        //        Console.ReadKey();
        //        Environment.Exit(0);
        //    }
        //    string xmlcontents = doc.InnerXml;
        //    var elements = XElement.Parse(xmlcontents);
        //    var valueofElements = elements.Elements("Book");
        //    foreach (var element in valueofElements)
        //    {
        //        testList.Add(new Book
        //        {
        //            name = element.Element("name").Value,
        //            author = element.Element("author").Value,
        //            ISBNnumber = element.Element("ISBNnumber").Value,
        //            //lastBorrow = element.Element("lastBorrow").Value
        //            borrower = element.Element("borrower").Value,
        //            //borrowed = element.Element("borrowed").Value, 
        //        });
        //    }
        //    foreach (var book in testList)
        //    {
        //        Console.WriteLine(book.name);
        //        Console.WriteLine(book.author);
        //        Console.WriteLine(book.ISBNnumber);
        //        Console.WriteLine(book.lastBorrow);
        //        Console.WriteLine(book.borrower);
        //        Console.WriteLine(book.borrowed);
        //    }

        //    Console.ReadKey();
        //}


    }
}
