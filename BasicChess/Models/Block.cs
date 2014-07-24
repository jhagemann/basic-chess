using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    class Block
    {
        public String X { get; set; }
        public int Y { get; set; }
        public Piece ChessPiece { get; set; }

        public Block(String x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
