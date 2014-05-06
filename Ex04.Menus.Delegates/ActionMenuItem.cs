using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public delegate void  DoActionDelegate();

    internal class ActionMenuItem : MenuItem
    {
        private readonly DoActionDelegate r_ActionDelegate;

        internal ActionMenuItem(string i_Name, DoActionDelegate i_ActionDelegate)
            : base(i_Name)
        {
            r_ActionDelegate = i_ActionDelegate;
        }

        internal override void Activate()
        {
            if (r_ActionDelegate != null)
            {
                r_ActionDelegate.Invoke();
            }
            Console.ReadKey();
        }
    }
}

