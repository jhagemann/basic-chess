using BasicChess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Rules
{
    class MoveScopeManager
    {
        public static void ScopeBoard(Board gameBoard)
        {
            List<Block> spaces = null;
            Piece chessPiece = null;
            int player;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    chessPiece = gameBoard.Blocks[x, y].ChessPiece;
                    
                    if (chessPiece != null)
                    {
                        player = chessPiece.PlayerId;
                        if (!chessPiece.Name.Equals("Pawn"))
                        {
                            spaces = MoveManager.FindAvailableMoveSpaces(gameBoard, gameBoard.Blocks[x, y]);
                        }
                        else
                        {
                            List<Block> tempSpaces = null;
                            bool reset = false;
                            if (chessPiece.MaxMoves == 2)
                            {
                                chessPiece.MaxMoves = 1;
                                reset = true;
                            }
                            tempSpaces = MoveManager.FindAvaliableDiagonalSpaces(gameBoard, gameBoard.Blocks[x, y]);
                            if (player == 1)
                            {
                                spaces = tempSpaces.FindAll(b => b.Y - 1 > y);
                            }
                            else
                            {
                                spaces = tempSpaces.FindAll(b => b.Y - 1 < y);
                            }

                            if (reset)
                            {
                                chessPiece.MaxMoves = 2;
                            }
                            
                        }
                        foreach (Block space in spaces)
                        {
                            if (player == 1)
                            {
                                space.WithinP1Scope = true;
                            }
                            else
                            {
                                space.WithinP2Scope = true;
                            }
                        }
                    }
                }
            }
        }

        public static void AlterScope(Board gameBoard, Block currentSpace)
        {
            List<Block> spaces = MoveManager.FindAvailableMoveSpaces(gameBoard, currentSpace);
            int player = currentSpace.ChessPiece.PlayerId;
            foreach (Block space in spaces)
            {
                if (player == 1)
                {
                    space.WithinP1Scope = false;
                }
                else
                {
                    space.WithinP2Scope = false;
                }
            }
            
        }
    }
}
