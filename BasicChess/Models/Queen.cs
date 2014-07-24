﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    class Queen : Piece
    {
        public Queen(String color, int id)
        {
            Name = "Queen";
            Alive = true;
            Color = color;
            Id = id;
        }
    }
}
