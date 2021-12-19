using System;
using System.Collections.Generic;
using table;
using chess;
using table.Enums;

namespace xadrez_console_2021
{
    class Screen
    {
        public static void PrintGame(GameController game)
        {
            PrintTable(game.tab);
            Console.WriteLine();
            PrintPiesesCaptured(game);
            Console.WriteLine("Turno: " + game.turn);
            Console.WriteLine("Aguardando a jogada: " + game.NameColor());
            Console.WriteLine();
        }
        public static void PrintGame(GameController game, bool[,] movementsAllowed)
        {
            PrintTable(game.tab, movementsAllowed);
            Console.WriteLine();
            PrintPiesesCaptured(game);
            Console.WriteLine("Turno: " + game.turn);
            Console.WriteLine("Aguardando a jogada: " + game.NameColor());
            Console.WriteLine();
        }
        public static void PrintPiesesCaptured(GameController game)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            PrintHashSet(game.PiecesCapturedColor(Color.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintHashSet(game.PiecesCapturedColor(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();

        }

        public static void PrintHashSet(HashSet<Piece> hashset)
        {
            Console.Write("[");
            foreach(Piece x in hashset)
            {
                Console.Write(x + " ");
            }
            Console.Write(" ]");
        }

        public static void PrintTable(Table tab)
        {
            for (int i = 0; i < tab.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunms; j++)
                {
                    PrintPiece(tab.GetPiece(i, j));                        
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintTable(Table tab, bool[,] movementsAllowed)
        {
            ConsoleColor bgColorOriginal = Console.BackgroundColor;
            ConsoleColor bgColorAltered = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Rows; i++)
            {
                Console.BackgroundColor = bgColorOriginal;
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.Colunms; j++)
                {
                    if(movementsAllowed[i,j])
                    {
                        Console.BackgroundColor = bgColorAltered;
                    }
                    else
                    {
                        Console.BackgroundColor = bgColorOriginal;
                    }
                    PrintPiece(tab.GetPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = bgColorOriginal;
            Console.WriteLine("  a b c d e f g h");
        }

        public static PositionChess ReadPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new PositionChess(column, row);
        }


        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }


    }
}
