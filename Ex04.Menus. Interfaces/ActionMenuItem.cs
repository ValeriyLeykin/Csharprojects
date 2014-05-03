using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal class ActionMenuItem: MenuItem
    {
        private readonly Action r_Action;
        private readonly IDoAction r_Observer;

        public ActionMenuItem(string name, Action action, IDoAction observer) : base(name)
        {
            r_Action = action;
            r_Observer = observer;
        }

        internal override void Activate()
        {
            r_Observer.DoAction(r_Action);
        }
    }
}
