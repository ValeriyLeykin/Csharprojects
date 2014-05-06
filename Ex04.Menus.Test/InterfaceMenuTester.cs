using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class InterfaceMenuTester: IDoAction
    {
       private readonly List<Action> r_validActions;
       private readonly MethodToTest r_Methods;
       private readonly MainMenu r_InterfaceMainMenu;
          
       internal InterfaceMenuTester()
       {
           r_InterfaceMainMenu = new MainMenu();
           r_validActions = new List<Action>();
           r_Methods = new MethodToTest();
           Init();
       }
              
       private void Init()
       {
           ComplexMenuItem rootItem = r_InterfaceMainMenu.RootItem;
           ComplexMenuItem menuItem = null;
           menuItem = rootItem.AddComplexSubItem("Show Date/Time");
           Action action = new Action("ShowTime");
           r_validActions.Add(action);
           menuItem.AddActionSubItem("Show Time", action, this as IDoAction);
           action = new Action("ShowDate");
           r_validActions.Add(action);
           menuItem.AddActionSubItem("Show Date", action, this as IDoAction);
           action = new Action("WordsCounter");
           r_validActions.Add(action);
           rootItem.AddActionSubItem("Words Counter", action, this as IDoAction);
           action = new Action("ShowVersion");
           r_validActions.Add(action);
           rootItem.AddActionSubItem("Show Version", action, this as IDoAction);
       }

       public void DoAction(Action action)
       {
           if (r_validActions.Contains(action))
           {
              string methodName = action.ActionName;
              MethodInfo methodInfo = r_Methods.GetType().GetMethod(methodName);
              methodInfo.Invoke(r_Methods, null);
           }
       }

       internal void DemonstrateMenu()
       {
           r_InterfaceMainMenu.Show();
       }
    }
}
