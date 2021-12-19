using System;
using table;
using table.Enums;

namespace chess
{
    class GameController
    {
        public Table tab { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
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
        public void ValidatePositionOfOrigin(Position pos)
        {
            if (tab.GetPiece(pos) == null)
            {
                throw new TableException("Não existe peça na posição de origem escolhida!");
            }
            if(currentPlayer != tab.GetPiece(pos).color)
            {
                throw new TableException("A peça de origem atual não é a sua!");
            }
            if (!tab.GetPiece(pos).ThereArePossibleMoves())
            {
                throw new TableException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidatePositionOfDestin(Position origin, Position destin)
        {
            if (!tab.GetPiece(origin).CanMoveTo(destin))
            {
                throw new TableException("Posição de destino invalida!");
            }

        }

        public void PlayTurn(Position origin, Position destin)
        {
            PlayMove(origin, destin);
            turn++;
            ChangePlayer();

        }
        private void ChangePlayer()
        {
            if (currentPlayer == Color.White)
                currentPlayer = Color.Black;
            else
                currentPlayer = Color.White;
        }
        public string NameColor()
        {
            if (currentPlayer == Color.White)
                return "Branca";
            else
                return "Preta";
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
