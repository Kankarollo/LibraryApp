using LibraryApp.BookRepositoryFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryApp.DataLoader
{
    class JSONService : IJSONService
    {
        private string _pathToFile = null;

        public  List<Book> ConvertJsonToList(string pathname)
        {
            _pathToFile = "DataFiles/" + pathname;
            try
            {
                using (StreamReader r = new StreamReader(_pathToFile))
                {
                    string json = r.ReadToEnd();
                    List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
                    var test = JsonConvert.SerializeObject(books);

                    return books;
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found!");
                Console.ReadLine();
                Environment.Exit(0);
                return null;
            }
        }

        public void SaveChangesToJsonFile(IEnumerable<Book> bookListToSave)
        {
            var jsonData = JsonConvert.SerializeObject(bookListToSave);
            File.WriteAllText(_pathToFile, jsonData);
        }
    }
}
