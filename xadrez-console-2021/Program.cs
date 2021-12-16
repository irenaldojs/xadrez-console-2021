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
            PositionChess pos = new PositionChess('c', 7);

            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPosition());

            Console.ReadLine();
        }
    }
}
