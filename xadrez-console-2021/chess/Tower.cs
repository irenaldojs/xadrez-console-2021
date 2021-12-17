using table;
using table.Enums;
namespace chess
{
    class Tower : Piece
    {
        public Tower(Table tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "T";
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

            // Move Up
            pos.SetPosition(position.Row - 1, position.Colunm);
            while(tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
                Piece aux = tab.GetPiece(pos);
                if (aux != null && aux.color != color)
                {
                    break;
                }
                pos.SetPosition(pos.Row - 1, pos.Colunm);
            }
            // Move Down
            pos.SetPosition(position.Row + 1, position.Colunm);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
                Piece aux = tab.GetPiece(pos);
                if (aux != null && aux.color != color)
                {
                    break;
                }
                pos.SetPosition(pos.Row + 1, pos.Colunm);
            }
            // Move Right
            pos.SetPosition(position.Row, position.Colunm + 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
                Piece aux = tab.GetPiece(pos);
                if (aux != null && aux.color != color)
                {
                    break;
                }
                pos.SetPosition(pos.Row, pos.Colunm + 1);
            }
            // Move LEft
            pos.SetPosition(position.Row, position.Colunm - 1);
            while (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
                Piece aux = tab.GetPiece(pos);
                if (aux != null && aux.color != color)
                {
                    break;
                }
                pos.SetPosition(pos.Row, pos.Colunm - 1);
            }

            return mat;
        }
    }
}
