using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    internal class DelegateMenuTester
    {
        private readonly MethodToTest r_Methods;
        private readonly MainMenu r_DelegateMainMenu;

        internal DelegateMenuTester()
        {
            r_Methods = new MethodToTest();
            r_DelegateMainMenu = new MainMenu();
            Init();
        }

        private void Init()
        {
            ComplexMenuItem rootItem = r_DelegateMainMenu.RootItem;
            ComplexMenuItem menuItem = null;
            menuItem = rootItem.AddComplexSubItem("Show Date/Time");
            menuItem.AddActionSubItem("Show Time", r_Methods.ShowTime);
            menuItem.AddActionSubItem("Show Date", r_Methods.ShowDate);
            rootItem.AddActionSubItem("Words Counter", r_Methods.WordsCounter);
            rootItem.AddActionSubItem("Show Version", r_Methods.ShowVersion);
        }

        internal void DemonstrateMenu()
        {
            r_DelegateMainMenu.Show();
        }

    }
}
