using table.Enums;

namespace table
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Table tab { get; protected set; }
        public Color color { get; protected set; }
        public int numberSteps { get; protected set; }
        

        public Piece(Table tabaux, Color coloraux)
        {
            position = null;
            color = coloraux;
            tab = tabaux;
            numberSteps = 0;
        }

        public bool ThereArePossibleMoves()
        {
            bool[,] mat = MovementsAllowed();
            for (int i = 0; i < tab.Rows; i++)
            {
                for(int j = 0; j < tab.Colunms; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return MovementsAllowed()[pos.Row, pos.Colunm];
        }

        public void AdStep()
        {
            numberSteps++;
        }
        public void DecreaseStep()
        {
            numberSteps--;
        }


        public abstract bool[,] MovementsAllowed();
    }
}
