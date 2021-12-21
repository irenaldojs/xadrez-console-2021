using table;
using table.Enums;
namespace chess
{
    class Horse : Piece
    {
        public Horse(Table tab, Color color) : base(tab, color)
        {

        }
        public override string ToString()
        {
            return "C";
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

            // 1
            pos.SetPosition(position.Row - 2, position.Colunm + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // 2
            pos.SetPosition(position.Row - 1, position.Colunm + 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // 3
            pos.SetPosition(position.Row + 1, position.Colunm + 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // 4
            pos.SetPosition(position.Row + 2, position.Colunm + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // 5
            pos.SetPosition(position.Row + 2, position.Colunm - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // 6
            pos.SetPosition(position.Row + 1, position.Colunm - 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // 7
            pos.SetPosition(position.Row - 1, position.Colunm - 2);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // up+left position
            pos.SetPosition(position.Row - 2, position.Colunm - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }

            return mat;
        }
    }
}

