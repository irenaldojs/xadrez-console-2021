namespace table
{
    class Position
    {
        public int Row { get; set; }
        public int Colunm { get; set; }

        public Position(int row, int colunm)
        {
            this.Row = row;
            this.Colunm = colunm;
        }

        public override string ToString()
        {
            return Row 
                + " , "
                + Colunm;
        }
    }
}
