using System.Collections.Generic;

namespace LibraryApp.MenuFolder
{
    interface IMenu
    {
        Dictionary<int, string> MenuList();
        string MenuListWriter();
        void ShowMenu();
    }
}