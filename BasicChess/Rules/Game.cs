using BasicChess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Rules
{
    public class Game
    {
        public bool HasWinner { get; set; }
        public bool Player1Turn { get; set; }
        public Player[] Players { get; set; }
        public Board GameBoard { get; set; }

        public Game(String p1Name, String p1Color, String p2Name, String p2Color)
        {
            GameBoard = new Board();
            Players = new Player[2];
            Players[0] = new Player(1, p1Name, p1Color);
            Players[1] = new Player(2, p2Name, p2Color);

        }

        public void SetUpBoard()
        {
            //Add player 1's pieces
            //Block[0,0] can be visualized at bottom left hand corner of board
            //player 1 is always on bottom
            GameBoard.Blocks[0, 0].ChessPiece = Players[0].Pieces.First(p => p.Name == "Rook" && p.Id == 1); 
            GameBoard.Blocks[1, 0].ChessPiece = Players[0].Pieces.First(p => p.Name == "Knight" && p.Id == 1);
            GameBoard.Blocks[2, 0].ChessPiece = Players[0].Pieces.First(p => p.Name == "Bishop" && p.Id == 1);
            GameBoard.Blocks[3, 0].ChessPiece = Players[0].Pieces.First(p => p.Name == "Queen" && p.Id == 1);
            GameBoard.Blocks[4, 0].ChessPiece = Players[0].Pieces.First(p => p.Name == "King" && p.Id == 1);
            GameBoard.Blocks[5, 0].ChessPiece = Players[0].Pieces.First(p => p.Name == "Bishop" && p.Id == 2);
            GameBoard.Blocks[6, 0].ChessPiece = Players[0].Pieces.First(p => p.Name == "Knight" && p.Id == 2);
            GameBoard.Blocks[7, 0].ChessPiece = Players[0].Pieces.First(p => p.Name == "Rook" && p.Id == 2);

            for (int x = 0; x < 8; x++)
            {
                GameBoard.Blocks[x, 1].ChessPiece = Players[0].Pieces.First(p => p.Name == "Pawn" && p.Id == x + 1); 
            }

            //Add player 2's pieces
            GameBoard.Blocks[0, 7].ChessPiece = Players[1].Pieces.First(p => p.Name == "Rook" && p.Id == 1);
            GameBoard.Blocks[1, 7].ChessPiece = Players[1].Pieces.First(p => p.Name == "Knight" && p.Id == 1);
            GameBoard.Blocks[2, 7].ChessPiece = Players[1].Pieces.First(p => p.Name == "Bishop" && p.Id == 1);
            GameBoard.Blocks[3, 7].ChessPiece = Players[1].Pieces.First(p => p.Name == "Queen" && p.Id == 1);
            GameBoard.Blocks[4, 7].ChessPiece = Players[1].Pieces.First(p => p.Name == "King" && p.Id == 1);
            GameBoard.Blocks[5, 7].ChessPiece = Players[1].Pieces.First(p => p.Name == "Bishop" && p.Id == 2);
            GameBoard.Blocks[6, 7].ChessPiece = Players[1].Pieces.First(p => p.Name == "Knight" && p.Id == 2);
            GameBoard.Blocks[7, 7].ChessPiece = Players[1].Pieces.First(p => p.Name == "Rook" && p.Id == 2);

            for (int x = 0; x < 8; x++)
            {
                GameBoard.Blocks[x, 6].ChessPiece = Players[1].Pieces.First(p => p.Name == "Pawn" && p.Id == x + 1);
            }
            MoveScopeManager.ScopeBoard(this);
        }

        
    }
}
