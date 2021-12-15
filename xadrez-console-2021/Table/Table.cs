using System;
using System.Collections.Generic;
using System.Text;

namespace table
{
    class Table
    {
        public int Rows { get; set; }
        public int Colunms { get; set; }
        private Piece[,] pieces;

        public Table(int rows, int colunms)
        {
            this.Rows = rows;
            this.Colunms = colunms;
            pieces = new Piece[Rows, Colunms];
        }
    }
}
