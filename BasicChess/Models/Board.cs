﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class Board
    {
        public Block[,] Blocks { get; set; }

        public Board()
        {
            Blocks = new Block[8, 8];
            BuildBoard();
        }

        public void BuildBoard()
        {
            
            for (int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    Blocks[x - 1, y - 1] = new Block(x, y);
                }
            }
        }


        public Block FindBlock(String blockName)
        {
            String x = blockName.Substring(0, 1);
            int x2 = -1;
            switch (x)
            {
                case "a":
                    x2 = 0;
                    break;
                case "b":
                    x2 = 1;
                    break;
                case "c":
                    x2 = 2;
                    break;
                case "d":
                    x2 = 3;
                    break;
                case "e":
                    x2 = 4;
                    break;
                case "f":
                    x2 = 5;
                    break;
                case "g":
                    x2 = 6;
                    break;
                case "h":
                    x2 = 7;
                    break;
                default:
                    break;
            }

            int y = Convert.ToInt16(blockName.Substring(1, 1));
            return Blocks[x2, y];
        }


        public override string ToString()
        {
            String layout = "";
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (Blocks[x, y].ChessPiece == null)
                    {
                        layout += "0\t";
                    }
                    else
                    {
                        layout += "1\t";
                    }
                }
                layout += "\n";
                
            }
            return layout;            
        }

        
    }
}
