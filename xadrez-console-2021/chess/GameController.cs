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
        public Piece enPassant { get; private set; }
        public GameController()
        {
            tab = new Table(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            endGame = false;
            enPassant = null;
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
            // Special Move - Castle Kingside
            if (p is King && destin.Colunm == origin.Colunm + 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Colunm + 3);
                Position towerDestin = new Position(origin.Row, origin.Colunm + 1);
                Piece tower = tab.RemovePiece(towerOrigin);
                tower.AdStep();
                tab.PlacePiece(tower, towerDestin);
            }
            // Special Move - Castle Queenside
            if (p is King && destin.Colunm == origin.Colunm - 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Colunm - 4);
                Position towerDestin = new Position(origin.Row, origin.Colunm - 1);
                Piece tower = tab.RemovePiece(towerOrigin);
                tower.AdStep();
                tab.PlacePiece(tower, towerDestin);
            }
            // Special Move - En Passant
            if( p is Pawn)
            {
                if(origin.Colunm != destin.Colunm && capturePiece == null)
                {
                    Position posP;
                    if(p.color == Color.White)
                    {
                        posP = new Position(destin.Row + 1, destin.Colunm);
                    }
                    else
                    {
                        posP = new Position(destin.Row - 1, destin.Colunm);
                    }
                    capturePiece = tab.RemovePiece(posP);
                    captured.Add(capturePiece);
                }
            }

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

            // Special Move - En Passant
            Piece p = tab.GetPiece(destin);
            if(p is Pawn &&(destin.Row == origin.Row + 2 || destin.Row == origin.Row - 2))
            {
                enPassant = p;
            }
            else
            {
                enPassant = null;
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

            // Special Move - Castle Kingside
            if (p is King && destin.Colunm == origin.Colunm + 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Colunm + 3);
                Position towerDestin = new Position(origin.Row, origin.Colunm + 1);
                Piece tower = tab.RemovePiece(towerDestin);
                tower.DecreaseStep();
                tab.PlacePiece(tower, towerOrigin);
            }
            // Special Move - Castle Queenside
            if (p is King && destin.Colunm == origin.Colunm - 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Colunm - 4);
                Position towerDestin = new Position(origin.Row, origin.Colunm - 1);
                Piece tower = tab.RemovePiece(towerDestin);
                tower.DecreaseStep();
                tab.PlacePiece(tower, towerOrigin);
            }
            // Special Move - En Passant
            if(p is Pawn)
            {
                if(origin.Colunm != destin.Colunm && capturePiece == enPassant)
                {
                    Piece pawn = tab.RemovePiece(destin);
                    Position posP;
                    if(p.color == Color.White)
                    {
                        posP = new Position(3, destin.Colunm);
                    }
                    else
                    {
                        posP = new Position(4, destin.Colunm);
                    }
                    tab.PlacePiece(pawn, posP);
                }
            }

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
            // -- Brancas -- //
            InsertNewPiece('a', 1, new Tower(tab, Color.White));
            InsertNewPiece('b', 1, new Horse(tab, Color.White));
            InsertNewPiece('c', 1, new Bishop(tab, Color.White));
            InsertNewPiece('d', 1, new Queen(tab, Color.White));
            InsertNewPiece('e', 1, new King(tab, Color.White, this));
            InsertNewPiece('f', 1, new Bishop(tab, Color.White));
            InsertNewPiece('g', 1, new Horse(tab, Color.White));
            InsertNewPiece('h', 1, new Tower(tab, Color.White));
            InsertNewPiece('a', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('b', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('c', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('d', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('e', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('f', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('g', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('h', 2, new Pawn(tab, Color.White, this));

            // -- Brancas -- //
            InsertNewPiece('a', 8, new Tower(tab, Color.Black));
            InsertNewPiece('b', 8, new Horse(tab, Color.Black));
            InsertNewPiece('c', 8, new Bishop(tab, Color.Black));            
            InsertNewPiece('d', 8, new Queen(tab, Color.Black));
            InsertNewPiece('e', 8, new King(tab, Color.Black, this));
            InsertNewPiece('f', 8, new Bishop(tab, Color.Black));
            InsertNewPiece('g', 8, new Horse(tab, Color.Black));
            InsertNewPiece('h', 8, new Tower(tab, Color.Black));
            InsertNewPiece('a', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('b', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('c', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('d', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('e', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('f', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('g', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('h', 7, new Pawn(tab, Color.Black, this));


        }
    }
}
