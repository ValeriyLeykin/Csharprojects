using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Action
    {
        private readonly string r_ActionName;
        
        public Action(string i_ActionNamea)
        {
            r_ActionName = i_ActionNamea;
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
