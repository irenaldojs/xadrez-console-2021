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
        public bool check { get; private set; }
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

        public Piece PlayMove(Position origin, Position destin)
        {
            Piece p = tab.RemovePiece(origin);
            p.AdStep();
            Piece capturePiece = tab.RemovePiece(destin);
            tab.PlacePiece(p, destin);
            if(capturePiece != null)
                captured.Add(capturePiece);
            return capturePiece;
        }
        public void PlayTurn(Position origin, Position destin)
        {
            Piece capturePiece = PlayMove(origin, destin);
            if (IsInCheck(currentPlayer))
            {
                CancelMove(origin, destin, capturePiece);
                throw new TableException("Você não pode se colocar em xeque!");
            }

            check = IsInCheck(Target(currentPlayer));

            if (IsInCheckMate(Target(currentPlayer)))
            {
                endGame = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }


        }
        private void CancelMove(Position origin, Position destin, Piece capturePiece)
        {
            Piece p = tab.RemovePiece(destin);
            p.DecreaseStep();
            if(capturePiece != null)
            {
                tab.PlacePiece(capturePiece, destin);
                captured.Remove(capturePiece);
            }
            tab.PlacePiece(p, origin);
        }
        private void ChangePlayer()
        {
            if (currentPlayer == Color.White)
                currentPlayer = Color.Black;
            else
                currentPlayer = Color.White;
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
            foreach (Piece x in pieces)
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
        private Color Target(Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }
        private Piece GetKing(Color color)
        {

            if(PiecesInGameColor(color).Count == 0)
            {
                throw new TableException("Sem contagem");
            }

            foreach(Piece x in PiecesInGameColor(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }
        private bool IsInCheck(Color color)
        {
            Piece r = GetKing(color);

            if (r == null)
                throw new TableException("Rei não instanciado!");

            foreach(Piece x in PiecesInGameColor(Target(color)))
            {
                bool[,] mat = x.MovementsAllowed();
                if (mat[r.position.Row, r.position.Colunm])
                    return true;
            }
            return false;
        }
        public bool IsInCheckMate(Color color)
        {
            if (!IsInCheck(color))
                return false;

            foreach(Piece x in PiecesInGameColor(color))
            {
                bool[,] mat = x.MovementsAllowed();
                for(int i = 0; i<tab.Rows; i++)
                {
                    for(int j = 0; j<tab.Colunms; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destin = new Position(i, j);
                            Piece capturedPiece = PlayMove(origin, destin);
                            bool testCheck = IsInCheck(color);
                            CancelMove(origin, destin, capturedPiece);
                            if (!testCheck)
                                return false;
                        }
                    }
                }
            }
            return true;
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
            // InsertNewPiece('c', 7, new Tower(tab, Color.Black));
            // InsertNewPiece('c', 8, new Tower(tab, Color.Black));
            InsertNewPiece('d', 7, new Tower(tab, Color.Black));
            InsertNewPiece('e', 7, new Tower(tab, Color.Black));
            InsertNewPiece('e', 8, new Tower(tab, Color.Black));
            InsertNewPiece('d', 8, new King(tab, Color.Black));

        }
    }
}
