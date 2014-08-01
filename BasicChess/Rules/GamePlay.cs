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
        //Validation
        public static bool IsValidPieceChoice(Game game, String choice)
        {
            bool valid = MoveAuthenticator.IsValidPieceChoice(game, choice);
            if (valid)
            {
                Block space = game.GameBoard.FindBlock(choice);
                List<Block> moves = MoveManager.FindAvailableMoveSpaces(game.GameBoard, space);
                if (moves.Count == 0)
                {
                    valid = false;
                }
            }

            return valid;
        }

        public static bool IsValidMoveChoice(Game game, Block startBlock, String choice)
        {
            bool valid = false;
            if (!MoveAuthenticator.IsValidSpace(choice))
            {
                return valid;
            }
            Block endBlock = game.GameBoard.FindBlock(choice);
            List<Block> validMoves = MoveManager.FindAvailableMoveSpaces(game.GameBoard, startBlock);
            if (!MoveAuthenticator.IsValidMoveChoice(endBlock, validMoves))
            {
                return valid;
            }

            Board gameBoard = game.GameBoard;
            Board testBoard = game.GameBoard.Clone();
            Block psuedoStartBlock = testBoard.FindBlock(startBlock.Name());
            Block psuedoEndBlock = testBoard.FindBlock(endBlock.Name());
            game.GameBoard = testBoard;
            int player = game.Player1Turn ? 1 : 2;

            MakeMove(game, psuedoStartBlock, psuedoEndBlock);
            if (player == 1 && game.Players[0].InCheck)
            {
                game.Players[0].InCheck = false;
                valid = false;
            }
            else if (player == 2 && game.Players[1].InCheck)
            {
                game.Players[1].InCheck = false;
                valid = false;
            }
            game.GameBoard = gameBoard;            
            return true;

        }


        //Moves
        public static List<Block> FindAvailableMoveSpaces(Board gameBoard, Block block)
        {
            return MoveManager.FindAvailableMoveSpaces(gameBoard, block);
        }

        public static void MakeMove(Game game, Block startBlock, Block endBlock)
        {
            Board gameBoard = game.GameBoard;
            MoveScopeManager.AlterScope(gameBoard, startBlock);
            MoveManager.MakeMove(game.GameBoard, startBlock, endBlock);
            MoveScopeManager.ScopeBoard(game);
        }

        public static bool CheckForMate(Game game)
        {
            bool isMate = true;
            int player = game.Player1Turn ? 1 : 2;
            Board originalBoard = game.GameBoard;
            List<Block> moves = null;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Board boardClone = game.GameBoard.Clone();
                    game.GameBoard = boardClone;
                    if (boardClone.Blocks[x, y].ChessPiece != null && boardClone.Blocks[x, y].ChessPiece.PlayerId == player)
                    {
                        Block startBlock = boardClone.Blocks[x, y];
                        moves = FindAvailableMoveSpaces(boardClone, boardClone.Blocks[x, y]);
                        if (moves.Count != 0)
                        {
                            Block endBlock;
                            foreach (Block move in moves)
                            {
                                endBlock = move;
                                GamePlay.MakeMove(game, startBlock, endBlock);
                                if (player == 1 && game.Players[0].InCheck == false)
                                {
                                    isMate = false;
                                }
                                else if (player == 2 && game.Players[1].InCheck == false)
                                {
                                    isMate = false;
                                }
                                GamePlay.MakeMove(game, endBlock, startBlock);
                            }
                        }
                    }

                }
            }
            game.GameBoard = originalBoard;
            return isMate;
        }

        public static bool ValidCheckPiece(Game game, String choice)
        {
            List<Block> moves = ValidCheckMoves(game, choice);
            return moves.Count == 0 ? false : true;

        }

        public static List<Block> ValidCheckMoves(Game game, String choice)
        {
            List<Block> moves = new List<Block>();
            if (!IsValidPieceChoice(game, choice))
            {
                return moves;
            }
            Board originalBoard = game.GameBoard;
            game.GameBoard = game.GameBoard.Clone();
            int player = game.Player1Turn ? 1 : 2;
            Block startBlock = game.GameBoard.FindBlock(choice);
            List<Block> potentialMoves = FindAvailableMoveSpaces(game.GameBoard, startBlock);
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

        public static bool ValidCheckMove(Game game,String choice, List<Block> validMoves)
        {
            bool valid = false;
            if (!MoveAuthenticator.IsValidSpace(choice))
            {
                return valid;
            }
            Block endSpace = game.GameBoard.FindBlock(choice);
            if (!validMoves.Contains(endSpace))
            {
                return valid;
            }

            return true;

        }
    }
}
