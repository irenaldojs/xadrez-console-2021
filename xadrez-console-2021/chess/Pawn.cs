using table;
using table.Enums;
namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Table tab, Color color) : base(tab, color) { }
        public override string ToString()
        {
            return "P";
        }

        private bool ThereIsEnemy(Position pos)
        {
            Piece p = tab.GetPiece(pos);
            return p != null && p.color != color;
        }

        private bool EmptyPosition(Position pos)
        {
            return tab.GetPiece(pos) == null;
        }

        public override bool[,] MovementsAllowed()
        {
            bool[,] mat = new bool[this.tab.Rows, this.tab.Colunms];

            Position pos = new Position(0, 0);

            if(color == Color.White)
            {
                pos.SetPosition(position.Row - 1, position.Colunm);
                if (tab.ValidPosition(pos) && EmptyPosition(pos))
                {
                    mat[pos.Row, pos.Colunm] = true;
                }

                pos.SetPosition(position.Row - 2, position.Colunm);
                if (tab.ValidPosition(pos) && EmptyPosition(pos) && numberSteps == 0)
                {
                    mat[pos.Row, pos.Colunm] = true;
                }

                pos.SetPosition(position.Row - 1, position.Colunm - 1);
                if (tab.ValidPosition(pos) && ThereIsEnemy(pos))
                {
                    mat[pos.Row, pos.Colunm] = true;
                }

                pos.SetPosition(position.Row - 1, position.Colunm + 1);
                if (tab.ValidPosition(pos) && ThereIsEnemy(pos))
                {
                    mat[pos.Row, pos.Colunm] = true;
                }
            }
            else
            {
                pos.SetPosition(position.Row + 1, position.Colunm);
                if (tab.ValidPosition(pos) && EmptyPosition(pos))
                {
                    mat[pos.Row, pos.Colunm] = true;
                }

                pos.SetPosition(position.Row + 2, position.Colunm);
                if (tab.ValidPosition(pos) && EmptyPosition(pos) && numberSteps == 0)
                {
                    mat[pos.Row, pos.Colunm] = true;
                }

                pos.SetPosition(position.Row + 1, position.Colunm - 1);
                if (tab.ValidPosition(pos) && ThereIsEnemy(pos))
                {
                    mat[pos.Row, pos.Colunm] = true;
                }

                pos.SetPosition(position.Row + 1, position.Colunm + 1);
                if (tab.ValidPosition(pos) && ThereIsEnemy(pos))
                {
                    mat[pos.Row, pos.Colunm] = true;
                }
            }
            return mat;
        }
    }
}

