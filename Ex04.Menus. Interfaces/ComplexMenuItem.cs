using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class ComplexMenuItem: MenuItem
    {
        private readonly List<MenuItem> r_MenuItemsCollection;
        private readonly ComplexMenuItem r_ParentItem;

        internal ComplexMenuItem ParentItem
        {
            get
            {
                return r_ParentItem;
            }
        }

        internal int SubItemsCount 
        {
            get
            {
                return r_MenuItemsCollection.Count;
            }
        }

        internal ComplexMenuItem(string name, ComplexMenuItem parentItem = null) : base(name)
        {
            r_MenuItemsCollection = new List<MenuItem>();
            r_ParentItem = parentItem;
        }

        public ComplexMenuItem AddComplexSubItem(string name)
        {
            ComplexMenuItem subItem = new ComplexMenuItem(name, this);
            r_MenuItemsCollection.Add(subItem);
            return subItem;
        } 

        internal MenuItem GetChosenItem(int menuItemNum)
        {
            // second verification inside the method
            if (r_MenuItemsCollection.Count <= menuItemNum)
            {
                throw new ArgumentException("Out of range exception");
            }
            return r_MenuItemsCollection[menuItemNum];
        }

        internal override void Activate()
        {
            printSubItems();
        }

        private void printSubItems()
        {
            Console.Clear();
            StringBuilder menuItems = new StringBuilder();
            menuItems.Append(Name);
            if (r_ParentItem == null)
            {
                menuItems.Append("\n0: Exit\n");
            }
            else
            {
                menuItems.Append("\n0: Back\n");
            }
           
            for (int i = 0; i < r_MenuItemsCollection.Count; i++)
            {
                menuItems.Append(String.Format("{0}: {1}\n", i + 1, r_MenuItemsCollection[i].Name));
            }
            Console.WriteLine(menuItems);
        }

        public void AddActionSubItem(string name, Action action, IDoAction observer)
        {
            ActionMenuItem subItem = new ActionMenuItem(name, action, observer);
            r_MenuItemsCollection.Add(subItem);
        }
    }
}
