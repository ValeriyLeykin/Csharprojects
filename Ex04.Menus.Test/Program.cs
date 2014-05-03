using System;
using System.Collections.Generic;
using System.Text;


namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main()
        {
            InterfaceMenuBuilder menuBuilder = new InterfaceMenuBuilder();
            menuBuilder.InterfaceMenu.Show();
        }
    }
}
