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
            Table tab = new Table(8, 8);

            tab.PlacePiece(new Tower(tab, Color.Preta), new Position(0, 0));
            tab.PlacePiece(new Tower(tab, Color.Preta), new Position(1, 3));
            tab.PlacePiece(new King(tab, Color.Preta), new Position(2, 4));

            Screen.PrintTable(tab);

            Console.ReadLine();
        }
    }
}
