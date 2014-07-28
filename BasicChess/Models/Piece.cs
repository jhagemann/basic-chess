using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    public class Piece
    {
        public String Name { get; set; }
        public bool Alive { get; set; }
        public String Color { get; set; }
        public int Id { get; set; }
        public bool HasMoved { get; set; }
        public int PlayerId { get; set; }
        //-1 is infinite
        public int MaxMoves { get; set; }
        
    }
}
