using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal class ActionMenuItem:MenuItem
    {
        private readonly Action r_Action;
        private readonly IDoAction r_Observer;

        public ActionMenuItem(string i_Name, Action i_Action, IDoAction i_Observer)
            : base(i_Name)
        {
            r_Action = i_Action;
            r_Observer = i_Observer;
        }

        internal override void Activate()
        {
            r_Observer.DoAction(r_Action);
            Console.ReadKey();
        }
    }
}
