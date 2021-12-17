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

        public void AdStep()
        {
            numberSteps++;
        }

        public abstract bool[,] MovementsAllowed();
    }
}
