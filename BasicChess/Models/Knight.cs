using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class Knight : Piece
    {
        public Knight(String color, int id)
        {
            Name = "Knight";
            Alive = true;
            Color = color;
            Id = id;
        }
    }
}
