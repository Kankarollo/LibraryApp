using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.BookRepositoryFolder
{
   public class Book
    {
        public string name { get; set; }
        public string author { get; set; }
        public string  ISBNnumber { get; set; }
        public DateTime lastBorrow { get; set; }
        public string borrower { get; set; }
        public bool borrowed { get; set; } 
    }
}
