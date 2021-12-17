using table;
using table.Enums;
namespace chess
{
    class King : Piece
    {
        public King(Table tab, Color color) : base(tab, color){}
        public override string ToString()
        {
            return "R";
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

            // up position
            pos.SetPosition(position.Row - 1, position.Colunm);
            if(tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // up+right position
            pos.SetPosition(position.Row - 1, position.Colunm + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // right position
            pos.SetPosition(position.Row, position.Colunm + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // bot+right position
            pos.SetPosition(position.Row + 1, position.Colunm + 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // bot position
            pos.SetPosition(position.Row + 1, position.Colunm);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // bot+left position
            pos.SetPosition(position.Row + 1, position.Colunm - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // left position
            pos.SetPosition(position.Row, position.Colunm - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }
            // up+left position
            pos.SetPosition(position.Row - 1, position.Colunm - 1);
            if (tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Colunm] = true;
            }

            return mat;
        }
    }
}
