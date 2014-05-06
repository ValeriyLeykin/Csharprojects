using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private const int k_BackRequest = 0;
        private readonly ComplexMenuItem r_menuItemsRoot;
        private ComplexMenuItem m_CurrentComplexItem;

        public ComplexMenuItem RootItem
        {
            get
            {
                return r_menuItemsRoot;
            }
        }

        public MainMenu()
        {
            r_menuItemsRoot = new ComplexMenuItem("Main Menu", null);
            m_CurrentComplexItem = r_menuItemsRoot;
        }

        public void Show()
        {
            bool quitRequest = false;
            int userChoice;

            while (!quitRequest)
            {
                m_CurrentComplexItem.Activate();

                userChoice = getInput();

                if (userChoice == k_BackRequest)
                {
                    if (m_CurrentComplexItem == r_menuItemsRoot)
                    {
                        quitRequest = true;
                    }
                    else
                    {
                        m_CurrentComplexItem = m_CurrentComplexItem.ParentItem;
                    }
                }
                else
                {
                    m_CurrentComplexItem = m_CurrentComplexItem.ChooseItem(userChoice - 1);
                }
            }
        }

        private bool checkInputValid(string i_Input, out int o_CheckedInput)
        {
            bool result = false;
            result = Int32.TryParse(i_Input, out o_CheckedInput);

            if (result)
            {
                result = false;

                if (o_CheckedInput <= m_CurrentComplexItem.SubItemsQuantity && o_CheckedInput >= k_BackRequest)
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
