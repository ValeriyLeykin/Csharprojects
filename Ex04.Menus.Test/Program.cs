using System;
using System.Collections.Generic;
using System.Text;


namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Now you will be demonstrated the interface menu:\n");
            Console.ReadKey();
            InterfaceMenuTester m_InterfaceMenuTester = new InterfaceMenuTester();
            m_InterfaceMenuTester.DemonstrateMenu();
           
            Console.Clear();
            Console.WriteLine("Now you will be demonstrated the delegate menu:\n");
            Console.ReadKey();
            DelegateMenuTester m_DelegateMenuTester = new DelegateMenuTester();
            m_DelegateMenuTester.DemonstrateMenu();

        }
    }
}
