using table;
using table.Enums;
namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Table tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position pos)
        {
            Piece p = tab.GetPiece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] MovementsAllowed()
        {
            bool[,] mat = new bool[this.tab.Rows, this.tab.Colunms];

            Position pos = new Position(0, 0);

            // Move Up+Right
            pos.SetPosition(position.Row - 1, position.Colunm + 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
                Piece aux = tab.GetPiece(pos);
                if (aux != null && aux.color != color)
                {
                    break;
                }
                pos.SetPosition(pos.Row - 1, pos.Colunm + 1);
            }
            // Move Down+Right
            pos.SetPosition(position.Row + 1, position.Colunm + 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
                Piece aux = tab.GetPiece(pos);
                if (aux != null && aux.color != color)
                {
                    break;
                }
                pos.SetPosition(pos.Row + 1, pos.Colunm + 1);
            }
            // Move Up+Left
            pos.SetPosition(position.Row - 1, position.Colunm - 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
                Piece aux = tab.GetPiece(pos);
                if (aux != null && aux.color != color)
                {
                    break;
                }
                pos.SetPosition(pos.Row - 1, pos.Colunm - 1);
            }
            // Move Down+Left
            pos.SetPosition(position.Row + 1, position.Colunm - 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
                Piece aux = tab.GetPiece(pos);
                if (aux != null && aux.color != color)
                {
                    break;
                }
                pos.SetPosition(pos.Row + 1, pos.Colunm - 1);
            }

            return mat;
        }
    }
}

