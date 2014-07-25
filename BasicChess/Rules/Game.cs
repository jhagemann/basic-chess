using BasicChess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Rules
{
    class Game
    {
        public bool HasWinner { get; set; }
        public int PlayersTurn { get; set; }
        public Player[] Players { get; set; }
        public Board GameBoard { get; set; }

        public Game(String p1Name, String p1Color, String p2Name, String p2Color)
        {
            GameBoard = new Board();
            Players = new Player[2];
            Players[0] = new Player(1, p1Name, p1Color);
            Players[1] = new Player(2, p2Name, p2Color);

        }
    }
}
