﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class Knight : Piece
    {
        public Knight(String color, int id, int playerId)
        {
            Name = "Knight";
            Alive = true;
            Color = color;
            Id = id;
            MaxMoves = 3;
            PlayerId = playerId;
        }
    }
}
