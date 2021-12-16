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
                Table tab = new Table(8, 8);
                tab.PlacePiece(new Tower(tab, Color.Black), new Position(0,0));
                tab.PlacePiece(new Tower(tab, Color.Black), new Position(1, 3));
                tab.PlacePiece(new King(tab, Color.Black), new Position(0, 2));

                tab.PlacePiece(new Tower(tab, Color.White), new Position(3, 5));

                Screen.PrintTable(tab);
            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
