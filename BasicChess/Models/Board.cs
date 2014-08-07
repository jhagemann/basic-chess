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
        public bool IsClone { get; set; }
        public static Dictionary<string, int> xDictionary;
        public Board()
        {
            Blocks = new Block[8, 8];
            if (xDictionary == null)
            {
                BuildDictionary();
            }
            BuildBoard();
        }

        public void BuildDictionary()
        {
            xDictionary = new Dictionary<string, int>();
            xDictionary.Add("a", 0);
            xDictionary.Add("b", 1);
            xDictionary.Add("c", 2);
            xDictionary.Add("d", 3);
            xDictionary.Add("e", 4);
            xDictionary.Add("f", 5);
            xDictionary.Add("g", 6);
            xDictionary.Add("h", 7);
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

        public Board Clone()
        {
            Board board = new Board();
            board.IsClone = true;
            for (int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    board.Blocks[x - 1, y - 1] = this.Blocks[x - 1,y - 1].Clone();
                }
            }
            return board;            
        }

        public Block FindBlock(String blockName)
        {            
            int x = xDictionary[blockName.Substring(0, 1)];
            int y = Convert.ToInt16(blockName.Substring(1, 1)) - 1;
            return Blocks[x, y];
        }


        public override string ToString()
        {
            String layout = "";
            int player;
            for (int y = 7; y >= 0; y--)
            {
                layout += y + 1 + "\t";
                for (int x = 0; x < 8; x++)
                {
                    if (Blocks[x, y].ChessPiece == null)
                    {
                        layout += "-\t";
                    }
                    else                        
                    {
                        player = Blocks[x, y].ChessPiece.PlayerId;
                        if (Blocks[x, y].ChessPiece.Name.Equals("Pawn"))
                        {
                            layout += "P" + player + "\t";
                        }
                        else if (Blocks[x, y].ChessPiece.Name.Equals("Rook"))
                        {
                            layout += "R" + player + "\t";
                        }
                        else if (Blocks[x, y].ChessPiece.Name.Equals("Knight"))
                        {
                            layout += "N" + player + "\t";
                        }
                        else if (Blocks[x, y].ChessPiece.Name.Equals("Bishop"))
                        {
                            layout += "B" + player + "\t";
                        }
                        else if (Blocks[x, y].ChessPiece.Name.Equals("Queen"))
                        {
                            layout += "Q" + player + "\t";
                        }
                        else if (Blocks[x, y].ChessPiece.Name.Equals("King"))
                        {
                            layout += "K" + player + "\t";
                        }
                        else
                        {
                            layout += "?" + player + "\t";
                        }
                    }
                }
                layout += "\n\n";
                
            }
            layout += " \ta\tb\tc\td\te\tf\tg\th\t\n";
            return layout;            
        }

        public string ScopePrint()
        {
            String layout = "";
            for (int y = 7; y >= 0; y--)
            {
                layout += y + 1 + "\t";
                for (int x = 0; x < 8; x++)
                {
                    if (Blocks[x, y].WithinP1Scope)
                    {
                        layout += "1";
                    }
                    if (Blocks[x, y].WithinP2Scope)
                    {
                        layout += "2";
                    }
                    if (!Blocks[x, y].WithinP1Scope && !Blocks[x, y].WithinP2Scope)
                    {
                        layout += "-";
                    }
                    layout += "\t";
                }
                layout += "\n\n";
            }

            layout += " \ta\tb\tc\td\te\tf\tg\th\t\n";
            return layout; 
        }

        
    }
}
