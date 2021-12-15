using table.Enums;

namespace table
{
    class Piece
    {
        public Position position { get; set; }
        public Table tab { get; protected set; }
        public Color color { get; protected set; }
        public int numberSteps { get; protected set; }
        

        public Piece(Table tab, Color color)
        {
            this.position = null;
            this.color = color;
            this.tab = tab;
            this.numberSteps = 0;
        }
    }
}
