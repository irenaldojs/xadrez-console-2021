using System;
using System.Collections.Generic;
using System.Text;

namespace table
{
    class Table
    {
        public int Rows { get; set; }
        public int Colunms { get; set; }
        private Piece[,] pieces;

        public Table(int rows, int colunms)
        {
            this.Rows = rows;
            this.Colunms = colunms;
            pieces = new Piece[Rows, Colunms];
        }

        public Piece GetPiece (int row, int colunm)
        {
            return pieces[row, colunm];
        }
        public Piece GetPiece(Position p)
        {
            return pieces[p.Row, p.Colunm];
        }

        public bool ContainPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos) != null;
        }

        public void PlacePiece(Piece p, Position pos)
        {
            if (ContainPiece(pos))
            {
                throw new Exception("Já existe peça nesta posição!");
            }
            pieces[pos.Row, pos.Colunm] = p;
            p.position = pos;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Row < 0 || pos.Row >= Rows ||
                pos.Colunm < 0 || pos.Colunm >= Colunms) return false;

            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new Exception("Posição inválida!");
            }
        }
    }
}
