
using LibraryApp.BookRepositoryFolder;
using System.Collections.Generic;

namespace LibraryApp.MenuFolder
{
    interface IMenu
    {
        Dictionary<int, string> MenuDictionary();
        string MenuList();
        void ShowMenuUntilStoppedAndOperateCommands();
        void ExecuteCommandOrExit(string command);
        void ShowListOfBooks(SearchBy searchBy);
        void ShowAllBooks();
        void ShowClientsList();
    }
}