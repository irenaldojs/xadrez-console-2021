using System;
using table;
using table.Enums;

namespace xadrez_console_2021
{
    class Screen
    {
        public static void PrintTable(Table tab)
        {
            for (int i = 0; i < tab.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunms; j++)
                {
                    if (tab.GetPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(tab.GetPiece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }

    }
}
