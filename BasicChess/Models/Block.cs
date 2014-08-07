using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class Block
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool WithinP1Scope { get; set; }
        public bool WithinP2Scope { get; set; }
        public Piece ChessPiece { get; set; }
        public Piece PhantomPiece { get; set; }

        public Block(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Block Clone()
        {
            Block block = new Block(this.X, this.Y)
            {                
                WithinP1Scope = this.WithinP1Scope,
                WithinP2Scope = this.WithinP2Scope,                
                
            };

            if (this.ChessPiece != null)
            {
                block.ChessPiece = this.ChessPiece.Clone();
            }

            return block;
        }

        public String Name()
        {
            String name = "";
            switch (X)
            {                
                case 1:
                    name += "a";
                    break;
                case 2:
                    name += "b";
                    break;
                case 3:
                    name += "c";
                    break;
                case 4:
                    name += "d";
                    break;
                case 5:
                    name += "e";
                    break;
                case 6:
                    name += "f";
                    break;
                case 7:
                    name += "g";
                    break;
                case 8:
                    name += "h";
                    break;
                default:
                    break;
            }

            return name += Y;


        }
        public override string ToString()
        {
            String summary = Name();
            if (ChessPiece != null)
                summary += ": " + ChessPiece.Name;

            return summary;
        }
    }
}
