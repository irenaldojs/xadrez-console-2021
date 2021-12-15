using System;
using table;

namespace xadrez_console_2021
{
    class Screen
    {
        public static void PrintTable(Table tab)
        {
            for (int i = 0; i < tab.Rows; i++)
            {
                for (int j = 0; j < tab.Colunms; j++)
                {
                    if (tab.GetPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.GetPiece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
