using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    class Board
    {
        public Block[,] blocks { get; set; }

        public Board()
        {
            blocks = new Block[8, 8];
            BuildBoard();
        }

        public void BuildBoard()
        {
            String[] xs = { "a", "b", "c", "d", "e", "f", "g", "h" };
            for (int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    blocks[x, y] = new Block(xs[x-1], y);
                }
            }
        }
    }
}
