using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const int k_BackRequest = 0;
        private readonly ComplexMenuItem r_menuItemsRoot;
        private ComplexMenuItem m_CurrentItem;

        public ComplexMenuItem RootItem 
        {
            get
            {
                return r_menuItemsRoot;
            }
        }

        public MainMenu()
        {
            r_menuItemsRoot = new ComplexMenuItem("Main Menu");
            m_CurrentItem = r_menuItemsRoot;
        }

      
        public void Show()
        {
            bool quitRequest = false;

            while (!quitRequest)
            {
                // print current  item sub items
                m_CurrentItem.Activate();
                // gets input from the user
                int input = getInput();

                // Exit \ Back request
                if (input == k_BackRequest)
                {
                    // if current menu item is root - Exit
                    if (m_CurrentItem == r_menuItemsRoot)
                    {
                        quitRequest = true;
                    }
                    // else - go back
                    else
                    {
                        m_CurrentItem = m_CurrentItem.ParentItem;
                    }
                }
                else
                {
                    // get the chosen item
                    MenuItem chosenItem = m_CurrentItem.GetChosenItem(input - 1);
                    if (isComplexItem(chosenItem))
                    {
                        m_CurrentItem = chosenItem as ComplexMenuItem;
                    }
                    else
                    {
                        // perform action
                        chosenItem.Activate();
                        Console.ReadKey();
                    }
                }
            }
        }

        private bool isComplexItem(MenuItem menuItem)
        {
            return (menuItem is ComplexMenuItem);
        }

        private bool checkInputValid(string input, out int checkedInput)
        {
            bool result = false;
            result = Int32.TryParse(input, out checkedInput);
            if (result)
            {
                result = false;
                // check the number is in the borders of collection or it is BackRequest
                if (checkedInput <= m_CurrentItem.SubItemsCount
                    && checkedInput >= k_BackRequest)
                {
                    result = true;
                }
            }
            return result;
        }

        private int getInput()
        {
            string input;
            int checkedInput;
            Console.WriteLine("Please enter your choise:");
            input = Console.ReadLine();
            while (!checkInputValid(input, out checkedInput))
            {
                Console.WriteLine("Invalid input, please try again:");
                input = Console.ReadLine();
            }
            return checkedInput;
        }
    }
}
