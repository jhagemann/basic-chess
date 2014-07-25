using System;
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
            String[] xs = { "a", "b", "c", "d", "e", "f", "g", "h" };
            for (int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    Blocks[x - 1, y - 1] = new Block(xs[x-1], y);
                }
            }
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
