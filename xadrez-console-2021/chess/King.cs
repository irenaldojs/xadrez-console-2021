using table;
using table.Enums;
namespace chess
{
    class King : Piece
    {
        private GameController game;
        public King(Table tab, Color color, GameController game) : base(tab, color)
        {
            this.game = game;
        }
        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position pos)
        {
            Piece p = tab.GetPiece(pos);
            return p == null || p.color != this.color;  
        }

        private bool TestCastle(Position pos)
        {
            Piece p = tab.GetPiece(pos);
            return p != null
                && p is Tower
                && p.color == color
                && p.numberSteps == 0; 
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

            // # Castle
            if(numberSteps == 0 && !game.check)
            {
                // # Castle Kingside
                Position t1 = new Position(this.position.Row, this.position.Colunm + 3);

                if (TestCastle(t1))
                {
                    Position p1 = new Position(position.Row, position.Colunm + 1);
                    Position p2 = new Position(position.Row, position.Colunm + 2);
                    if( tab.GetPiece(p1) == null && tab.GetPiece(p2) == null)
                    {
                        mat[position.Row, position.Colunm + 2] = true;
                    } 
                }
                // # Castle Queenside
                Position t2 = new Position(this.position.Row, this.position.Colunm - 4);
                if (TestCastle(t2))
                {
                    Position p1 = new Position(position.Row, position.Colunm - 1);
                    Position p2 = new Position(position.Row, position.Colunm - 2);
                    Position p3 = new Position(position.Row, position.Colunm - 3);
                    if ( tab.GetPiece(p1) == null && tab.GetPiece(p2) == null && tab.GetPiece(p3) == null)
                    {
                        mat[position.Row, position.Colunm - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
