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
        public bool endGame { get; set; }

        public GameController()
        {
            tab = new Table(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            endGame = false;
            InsertPieces();
        }

        public void PlayMove(Position origin, Position destin)
        {
            Piece p = tab.RemovePiece(origin);
            p.AdStep();
            // Piece capturePiece = tab.RemovePiece(destin);
            tab.PlacePiece(p, destin);
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
