using System;
using System.Collections.Generic;
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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public GameController()
        {
            tab = new Table(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            endGame = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            InsertPieces();
        }

        public void PlayMove(Position origin, Position destin)
        {
            Piece p = tab.RemovePiece(origin);
            p.AdStep();
            Piece capturePiece = tab.RemovePiece(destin);
            tab.PlacePiece(p, destin);
            if(capturePiece != null)
                captured.Add(capturePiece);

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

        public HashSet<Piece> PiecesCapturedColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured)
            {
                if (x.color == color)
                    aux.Add(x);
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGameColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                    aux.Add(x);
            }
            aux.ExceptWith(PiecesCapturedColor(color));

            return aux;
        }

        public string NameColor()
        {
            if (currentPlayer == Color.White)
                return "Branca";
            else
                return "Preta";
        }

        public void InsertNewPiece(char column, int row, Piece piece)
        {
            tab.PlacePiece(piece, new PositionChess(column, row).ToPosition());
            pieces.Add(piece);
        }

        private void InsertPieces()
        {
            InsertNewPiece('c', 1, new Tower(tab, Color.White));
            InsertNewPiece('c', 2, new Tower(tab, Color.White));
            InsertNewPiece('d', 2, new Tower(tab, Color.White));
            InsertNewPiece('e', 2, new Tower(tab, Color.White));
            InsertNewPiece('e', 1, new Tower(tab, Color.White));
            InsertNewPiece('d', 1, new King(tab, Color.White));
            // ----------------------------- //
            InsertNewPiece('c', 7, new Tower(tab, Color.Black));
            InsertNewPiece('c', 8, new Tower(tab, Color.Black));
            InsertNewPiece('d', 7, new Tower(tab, Color.Black));
            InsertNewPiece('e', 7, new Tower(tab, Color.Black));
            InsertNewPiece('e', 8, new Tower(tab, Color.Black));
            InsertNewPiece('d', 8, new King(tab, Color.Black));

        }
    }
}
