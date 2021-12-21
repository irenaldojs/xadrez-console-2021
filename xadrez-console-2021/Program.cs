using System;
using table;
using table.Enums;
using chess;

namespace xadrez_console_2021
{
    class Program
    {
        static void Main()
        {
            try
            {
                GameController game = new GameController();
                while (!game.endGame)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintGame(game);                    

                        Console.Write("Digite a origem: ");
                        Position origim = Screen.ReadPositionChess(game).ToPosition();
                        game.ValidatePositionOfOrigin(origim);

                        bool[,] movementsAllowed = game.tab.GetPiece(origim).MovementsAllowed();
                        Console.Clear();
                        Screen.PrintGame(game, movementsAllowed);

                        Console.WriteLine();
                        Console.Write("Digite o destino: ");
                        Position destin = Screen.ReadPositionChess(game).ToPosition();
                        game.ValidatePositionOfDestin(origim, destin);

                        game.PlayTurn(origim, destin);
                    }
                    catch ( TableException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    

                }

                
            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
