﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class Pawn : Piece
    {
        
        public Pawn(String color, int id, int playerId)
        {
            Name = "Pawn";
            Alive = true;
            this.Color = color;
            this.Id = id;
            MaxMoves = 1;
            PlayerId = playerId;
        }
    }
}
