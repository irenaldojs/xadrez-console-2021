using System;
using table;
using table.Enums;
using chess;

namespace xadrez_console_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameController game = new GameController();

                Screen.PrintTable(game.tab);
            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
