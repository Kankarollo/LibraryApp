﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.BookRepositoryFolder
{
    class Book
    {
        public string name { get; set; }
        public string author { get; set; }
        public int ISBNnumber { get; set; }
        public DateTime lastBorrow { get; set; }
        public string borrower { get; set; }
        public bool borrowed { get; set; } 
    }
}