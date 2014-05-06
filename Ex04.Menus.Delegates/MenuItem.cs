using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        private string m_Name;

        internal string Name
        {
            get
            {
                return m_Name;
            }
        }

        protected MenuItem(string name)
        {
            m_Name = name;
        }

        internal abstract void Activate();
    }
}
