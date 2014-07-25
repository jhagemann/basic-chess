using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Models
{
    class Piece
    {
        public String Name { get; set; }
        public bool Alive { get; set; }
        public String Color { get; set; }
        public int Id { get; set; }
        public bool HasMoved { get; set; }
        
    }
}
