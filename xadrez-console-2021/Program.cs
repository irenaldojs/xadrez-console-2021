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
                        Screen.PrintTable(game.tab);

                        Console.WriteLine();
                        Console.WriteLine("Turno: " + game.turn);
                        Console.WriteLine("Aguardando a jogada: " + game.NameColor());
                        Console.WriteLine();

                        Console.Write("Digite a origem: ");
                        Position origim = Screen.ReadPositionChess().ToPosition();
                        game.ValidatePositionOfOrigin(origim);

                        bool[,] movementsAllowed = game.tab.GetPiece(origim).MovementsAllowed();
                        Console.Clear();
                        Screen.PrintTable(game.tab, movementsAllowed);

                        Console.WriteLine();
                        Console.Write("Digite o destino: ");
                        Position destin = Screen.ReadPositionChess().ToPosition();
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
