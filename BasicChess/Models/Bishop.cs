using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class Bishop : Piece
    {
        public Bishop(String color, int id, int playerId)
        {
            Name = "Bishop";
            Alive = true;
            Color = color;
            Id = id;
            MaxMoves = -1;
            PlayerId = playerId;
        }
    }
}
