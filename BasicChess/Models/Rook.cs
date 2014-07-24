using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    class Rook : Piece
    {
        public Rook(String color, int id)
        {
            Name = "Rook";
            Alive = true;
            Color = color;
            Id = id;
        }
    }
}
