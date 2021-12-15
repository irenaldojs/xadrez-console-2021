using table.Enums;

namespace table
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int numberSteps { get; protected set; }
        public Table tab { get; protected set; }

        public Piece(Position position, Color color, Table tab)
        {
            this.position = position;
            this.color = color;
            this.tab = tab;
            this.numberSteps = 0;
        }
    }
}
