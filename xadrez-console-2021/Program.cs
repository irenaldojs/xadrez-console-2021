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
                while (!game.endGame)
                {
                    Console.Clear();
                    Screen.PrintTable(game.tab);

                    Console.WriteLine();
                    Console.Write("Digite a origem: ");
                    Position origim = Screen.ReadPositionChess().ToPosition();
                    
                    bool[,] movementsAllowed = game.tab.GetPiece(origim).MovementsAllowed();
                    Console.Clear();
                    Screen.PrintTable(game.tab, movementsAllowed);

                    Console.WriteLine();
                    Console.Write("Digite o destino: ");
                    Position destin = Screen.ReadPositionChess().ToPosition();

                    game.PlayMove(origim, destin);

                }

                
            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
