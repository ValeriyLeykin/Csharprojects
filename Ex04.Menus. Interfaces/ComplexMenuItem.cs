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
        
        internal int SubItemsQuantity 
        {
            get
            {
                return r_MenuItemsCollection.Count;
            }
        }

        internal ComplexMenuItem(string i_Name, ComplexMenuItem i_ParentItem)
            : base(i_Name)
        {
            r_MenuItemsCollection = new List<MenuItem>();
            r_ParentItem = i_ParentItem;
        }

        public ComplexMenuItem AddComplexSubItem(string i_Name)
        {
            ComplexMenuItem subItem = new ComplexMenuItem(i_Name, this);
            r_MenuItemsCollection.Add(subItem);
            return subItem;
        } 

        private MenuItem getChosenItem(int i_MenuItemNum)
        {
            // last verification
            if (r_MenuItemsCollection.Count <= i_MenuItemNum)
            {
                throw new ArgumentException("Item is out of range");
            }
            return r_MenuItemsCollection[i_MenuItemNum];
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
            menuItems.Append(Environment.NewLine);
            menuItems.Append(Environment.NewLine);

            if (r_ParentItem == null)
            {
                menuItems.Append("0: Exit");
            }
            else
            {
                menuItems.Append("0: Back");
            }

            menuItems.Append(Environment.NewLine);

            for (int i = 0; i < r_MenuItemsCollection.Count; i++)
            {
                menuItems.Append(String.Format("{0}: {1}{2}", i + 1, r_MenuItemsCollection[i].Name, Environment.NewLine));
            }

            Console.WriteLine(menuItems);
        }

        public void AddActionSubItem(string i_Name, Action i_Action, IDoAction i_Observer)
        {
            ActionMenuItem subItem = new ActionMenuItem(i_Name, i_Action, i_Observer);
            r_MenuItemsCollection.Add(subItem);
        }

        internal ComplexMenuItem ChooseItem(int i_Item)
        {
            MenuItem chosenItem = getChosenItem(i_Item);
            ComplexMenuItem currItem = this;

            if (chosenItem is ActionMenuItem)
            {
                chosenItem.Activate();
            }
            else
            {
                currItem = chosenItem as ComplexMenuItem;
            }
            return currItem;
        }
    }
}
