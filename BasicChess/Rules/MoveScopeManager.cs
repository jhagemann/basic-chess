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
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (gameBoard.Blocks[x, y].ChessPiece != null)
                    {
                        spaces = MoveManager.FindAvailableMoveSpaces(gameBoard,gameBoard.Blocks[x, y]);
                        int player = gameBoard.Blocks[x, y].ChessPiece.PlayerId;
                        
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
