using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Action
    {
        private readonly string r_ActionName;
        
        public Action(string actionName)
        {
            r_ActionName = actionName;
        }

        public String ActionName
        {
            get
            {
                return r_ActionName;
            }
        }
    }
}
