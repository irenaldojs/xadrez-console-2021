namespace table
{
    class Position
    {
        public int Row { get; private set; }
        public int Colunm { get; private set; }

        public Position(int row, int colunm)
        {
            this.Row = row;
            this.Colunm = colunm;
        }

        public void SetPosition(int row, int column)
        {
            this.Row = row;
            this.Colunm = column;
        }

        public override string ToString()
        {
            return Row 
                + " , "
                + Colunm;
        }
    }
}
