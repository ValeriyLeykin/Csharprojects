using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    internal class MethodToTest
    {
        public void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }

        public void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        public void WordsCounter()
        {
            Console.WriteLine("Please enter some text.");
            string text = Console.ReadLine().Trim();
            int countWords = text.Split().Length;
            Console.WriteLine("There are {0} words in your text.", countWords);
        }

        public void ShowVersion()
        {
            Console.WriteLine("The version is 14.2.4.0");
        }
    }
}
