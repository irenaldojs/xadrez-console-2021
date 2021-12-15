using System;
using table;

namespace xadrez_console_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Table tab = new Table(8, 8);

            Screen.PrintTable(tab);

            Console.ReadLine();
        }
    }
}
