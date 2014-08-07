using BasicChess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Rules
{
    //Wraper Class for playing game, helps with seperation of duties between MoveAuthenticator, MoveManager, and MoveScopeManager
    public class GamePlay
    {
        
        public static bool IsValidPieceChoice(Game game, String choice)
        {
            bool valid = MoveAuthenticator.IsValidPieceChoice(game, choice);            
            if (valid)
            {                
                List<Block> moves = ValidMoves(game, choice);
                if (moves.Count == 0)
                {
                    valid = false;
                }
            }
            return valid;
        }

        public static List<Block> ValidMoves(Game game, String choice)
        {
            List<Block> moves = new List<Block>();
            
            Board originalBoard = game.GameBoard;
            game.GameBoard = originalBoard.Clone();
            int player = game.Player1Turn ? 1 : 2;
            Block startBlock = game.GameBoard.FindBlock(choice);
            List<Block> potentialMoves = MoveManager.FindAvailableMoveSpaces(game.GameBoard, startBlock);
            if (potentialMoves.Count != 0)
            {
                Block endBlock;
                foreach (Block move in potentialMoves)
                {
                    endBlock = move;
                    GamePlay.MakeMove(game, startBlock, endBlock);
                    if (player == 1 && game.Players[0].InCheck == false)
                    {
                        moves.Add(originalBoard.FindBlock(move.Name()));
                    }
                    else if (player == 2 && game.Players[1].InCheck == false)
                    {
                        moves.Add(originalBoard.FindBlock(move.Name()));
                    }
                    GamePlay.MakeMove(game, endBlock, startBlock);
                }
            }
            game.GameBoard = originalBoard;
            return moves;
        }


        public static bool ValidMove(Game game, Block startBlock, String choice)
        {
            bool valid = false;
            List<Block> validMoves = ValidMoves(game, startBlock.Name());
            Block endSpace = game.GameBoard.FindBlock(choice);
            if (!validMoves.Contains(endSpace))
            {
                return valid;
            }

            return true;

        }       

        


        //Moves
        

        public static void MakeMove(Game game, Block startBlock, Block endBlock)
        {
            Board gameBoard = game.GameBoard;
            MoveScopeManager.AlterScope(gameBoard, startBlock);
            MoveManager.MakeMove(game.GameBoard, startBlock, endBlock);
            MoveScopeManager.ScopeBoard(game);
        }


        //Check methods
        public static bool CheckForMate(Game game)
        {
            bool inMate = true;
            int player = game.Player1Turn ? 1 : 2;
            List<Block> validMoves = new List<Block>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                   
                    if (game.GameBoard.Blocks[x, y].ChessPiece != null && game.GameBoard.Blocks[x, y].ChessPiece.PlayerId == player)
                    {
                        Block startBlock = game.GameBoard.Blocks[x, y];
                        validMoves.AddRange(ValidMoves(game, startBlock.Name()));
                    }
                }
            }
            if (validMoves.Count != 0)
            {
                inMate = false;
            }
            else
            {
                if (game.Player1Turn)
                {
                    game.Players[0].IsWinner = true;
                }
                else
                {
                    game.Players[1].IsWinner = true;
                }
            }

            return inMate;
        }

        

        
    }
}
