using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class King : Piece
    {
        public King(String color, int id)
        {
            Name = "King";
            Alive = true;
            Color = color;
            Id = id;
            MaxMoves = 1;
        }
    }
}
