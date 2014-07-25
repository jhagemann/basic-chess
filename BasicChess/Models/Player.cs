using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class Player
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Piece[] Pieces { get; set; }
        public String Color { get; set; }

        public Player(int id, String name, String color)
        {
            Id = id;
            Name = name;
            Color = color;
            BuildPieces();
        }

        private void BuildPieces()
        {
            Pieces = new Piece[16];
            for (int i = 0; i < 8; i++)
            {
                Pieces[i] = new Pawn(Color, i + 1);
            }
            Pieces[8] = new Knight(Color, 1);
            Pieces[9] = new Knight(Color, 2);
            Pieces[10] = new Bishop(Color, 1);
            Pieces[11] = new Bishop(Color, 2);
            Pieces[12] = new Rook(Color, 1);
            Pieces[13] = new Rook(Color, 2);
            Pieces[14] = new Queen(Color, 1);
            Pieces[15] = new King(Color, 1);
        }
    }
}
