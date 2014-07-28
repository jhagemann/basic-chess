using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class Rook : Piece
    {
        public Rook(String color, int id, int playerId)
        {
            Name = "Rook";
            Alive = true;
            Color = color;
            Id = id;
            MaxMoves = -1;
            PlayerId = playerId;
        }
    }
}
