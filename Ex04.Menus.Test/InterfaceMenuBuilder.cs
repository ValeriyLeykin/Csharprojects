using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class InterfaceMenuBuilder: IDoAction
    {
        private readonly MainMenu r_interfaceMainMenu;

        internal MainMenu InterfaceMenu
        {
            get
            {
                return r_interfaceMainMenu;
            }
        }
       
       internal InterfaceMenuBuilder()
       {
           r_interfaceMainMenu = new MainMenu();
           Init();
       }

       public void ShowTime()
       {
           Console.WriteLine("Showing time");
       }

       public void ShowDate()
       {
           Console.WriteLine("Showing date");
       }

       public void WordsCounter()
       {
           Console.WriteLine("Words counter");
       }

       public void ShowVersion()
       {
           Console.WriteLine("Showing version");
       }

       private void Init()
       {
           ComplexMenuItem rootItem = r_interfaceMainMenu.RootItem;
           ComplexMenuItem menuItem = null;
           menuItem = rootItem.AddComplexSubItem("Show Date/Time");
           Action action = new Action("ShowTime");
           menuItem.AddActionSubItem("Show Time", action, this as IDoAction);
           action = new Action("ShowDate");
           menuItem.AddActionSubItem("Show Date", action, this as IDoAction);
           action = new Action("WordsCounter");
           rootItem.AddActionSubItem("Words Counter", action, this as IDoAction);
           action = new Action("ShowVersion");
           rootItem.AddActionSubItem("Show Version", action, this as IDoAction);
       }

       public void DoAction(Action action)
       {
           string methodName = action.ActionName;
           MethodInfo methodInfo = this.GetType().GetMethod(methodName);
           methodInfo.Invoke(this, null);
       }
    }
}
