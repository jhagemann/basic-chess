using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class Queen : Piece
    {
        public Queen(String color, int id)
        {
            Name = "Queen";
            Alive = true;
            Color = color;
            Id = id;
            MaxMoves = -1;
        }
    }
}
