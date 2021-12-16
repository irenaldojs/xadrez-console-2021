using System;
using table;
using table.Enums;

namespace chess
{
    class GameController
    {
        public Table tab { get; private set; }
        private int turn;
        private Color currentPlayer;

        public GameController()
        {
            tab = new Table(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            InsertPieces();
        }

        public void PlayMove(Position origin, Position destination)
        {
            Piece p = tab.RemovePiece(origin);
            p.AdStep();
            Piece capturePiece = tab.RemovePiece(destination);
            tab.PlacePiece(p, destination);
        }

        private void InsertPieces()
        {
            tab.PlacePiece(new Tower(tab, Color.White), new PositionChess('c', 1).ToPosition());
            tab.PlacePiece(new Tower(tab, Color.White), new PositionChess('c', 2).ToPosition());
            tab.PlacePiece(new Tower(tab, Color.White), new PositionChess('d', 2).ToPosition());
            tab.PlacePiece(new Tower(tab, Color.White), new PositionChess('e', 2).ToPosition());
            tab.PlacePiece(new Tower(tab, Color.White), new PositionChess('e', 1).ToPosition());
            tab.PlacePiece(new King(tab, Color.White), new PositionChess('d', 1).ToPosition());
            // ----------------------------- //
            tab.PlacePiece(new Tower(tab, Color.Black), new PositionChess('c', 7).ToPosition());
            tab.PlacePiece(new Tower(tab, Color.Black), new PositionChess('c', 8).ToPosition());
            tab.PlacePiece(new Tower(tab, Color.Black), new PositionChess('d', 7).ToPosition());
            tab.PlacePiece(new Tower(tab, Color.Black), new PositionChess('e', 7).ToPosition());
            tab.PlacePiece(new Tower(tab, Color.Black), new PositionChess('e', 8).ToPosition());
            tab.PlacePiece(new King(tab, Color.Black), new PositionChess('d', 8).ToPosition());

        }
    }
}
