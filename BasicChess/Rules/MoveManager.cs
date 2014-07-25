using BasicChess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Rules
{
    class MoveManager
    {
        //will return null in no piece is on selected space
        public static List<Block> FindAvailableMoveSpaces(Board gameBoard, Block block)
        {            
            if (block.ChessPiece == null)
            {
                return null;
            }

            List<Block> availableSpaces = null;
            Piece piece = block.ChessPiece;

            if(piece.Name.Equals("Pawn"))
            {
                availableSpaces = FindAvaliablePawnSpaces(gameBoard, block);
            }
            else if (piece.Name.Equals("Rook"))
            {
                availableSpaces = FindAvaliableRookSpaces(gameBoard, block);
            }
            else if (piece.Name.Equals("Knight"))
            {
                availableSpaces = FindAvaliableKnightSpaces(gameBoard, block);
            }
            else if (piece.Name.Equals("Bishop"))
            {
                availableSpaces = FindAvaliableBishopSpaces(gameBoard, block);
            }
            else if (piece.Name.Equals("Queen"))
            {
                availableSpaces = FindAvaliableQueenSpaces(gameBoard, block);
            }
            else if (piece.Name.Equals("King"))
            {
                availableSpaces = FindAvaliableKingSpaces(gameBoard, block);
            }

            
            return availableSpaces;
        }

        //These methods are where special conditions are set before calling find strait and diagnal space methods
        private static List<Block> FindAvaliableKnightSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces;
            return null;
        }

        private static List<Block> FindAvaliableRookSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces;
            return null;
        }
        private static List<Block> FindAvaliableBishopSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces;
            return null;
        }
        private static List<Block> FindAvaliablePawnSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces = null;
            if(currentBlock.ChessPiece.MaxMoves == 2)
            {
                currentBlock.ChessPiece.MaxMoves = 1;
            }
            if (currentBlock.ChessPiece.HasMoved == false)
            {
                currentBlock.ChessPiece.MaxMoves = 2;
            }

            return availableSpaces;
            
        }
        private static List<Block> FindAvaliableKingSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces;
            return null;
        }
        private static List<Block> FindAvaliableQueenSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces;
            return null;
        }

        private static List<Block> FindAvaliableStraitSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces = new List<Block>();
            int x = currentBlock.X -1;
            int y = currentBlock.Y -1;
            int maxSpaces = currentBlock.ChessPiece.MaxMoves;
            int maxCount = 0;
            int count = 0;
            //check up
            if (y < 7)
            {
                count = y+1;
                while (count <= 7 && maxCount <= maxSpaces)
                {
                    if (gameBoard.Blocks[x, count].ChessPiece == null)
                    {
                        availableSpaces.Add(gameBoard.Blocks[x, count]);
                    }
                    else if (!gameBoard.Blocks[x, count].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                    {
                        availableSpaces.Add(gameBoard.Blocks[x, count]);
                        break;
                    }
                    else
                    {
                        break;
                    }
                    count++;
                    maxCount++;
                }
            }

            //check down
            count = 0;
            maxCount = 0;
            if (y > 0)
            {
                count = y - 1;
                while (count >=0 && maxCount <= maxSpaces)
                {
                    if (gameBoard.Blocks[x, count].ChessPiece == null)
                    {
                        availableSpaces.Add(gameBoard.Blocks[x, count]);
                    }
                    else if (!gameBoard.Blocks[x, count].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                    {
                        availableSpaces.Add(gameBoard.Blocks[x, count]);
                        break;
                    }
                    else
                    {
                        break;
                    }
                    count--;
                    maxCount++;
                }
            }

            
            //check left
            count = 0;
            maxCount = 0;
            if (x > 0)
            {
                count = x - 1;
                while (count >= 0 && maxCount <= maxSpaces)
                {
                    if (gameBoard.Blocks[count, y].ChessPiece == null)
                    {
                        availableSpaces.Add(gameBoard.Blocks[count, y]);
                    }
                    else if (!gameBoard.Blocks[count, y].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                    {
                        availableSpaces.Add(gameBoard.Blocks[count, y]);
                        break;
                    }
                    else
                    {
                        break;
                    }
                    count--;
                    maxCount++;
                }
            }
            
            //check right
            count = 0;
            maxCount = 0;
            if (x < 7)
            {
                count = x + 1;
                while (count <= 7 && maxCount <= maxSpaces)
                {
                    if (gameBoard.Blocks[count, y].ChessPiece == null)
                    {
                        availableSpaces.Add(gameBoard.Blocks[count, y]);
                    }
                    else if (!gameBoard.Blocks[count, y].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                    {
                        availableSpaces.Add(gameBoard.Blocks[count, y]);
                        break;
                    }
                    else
                    {
                        break;
                    }
                    count++;
                    maxCount++;
                }
            }
            return availableSpaces;   
        }



        private static List<Block> FindAvaliableDiagonalSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces = new List<Block>();
            int x = currentBlock.X - 1;
            int y = currentBlock.Y - 1;
            int maxSpaces = currentBlock.ChessPiece.MaxMoves;
            int maxCount = 0;     
            int xCount = 0;
            int yCount = 0;

            //check up/right
            if (x != 7 && y != 7)
            {
                xCount = x + 1;
                yCount = y + 1;
                while (xCount <= 7 && yCount <= 7 && maxCount <= maxSpaces)
                {
                    if (gameBoard.Blocks[xCount, yCount].ChessPiece == null)
                    {
                        availableSpaces.Add(gameBoard.Blocks[xCount, yCount]);
                    }
                    else if (!gameBoard.Blocks[xCount, yCount].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                    {
                        availableSpaces.Add(gameBoard.Blocks[xCount, yCount]);
                        break;
                    }
                    else
                    {
                        break;
                    }

                    xCount++;
                    yCount++;
                    maxCount++;
                }
            }
            //check up/left
            if (x != 0 && y != 7)
            {
                xCount = x - 1;
                yCount = y + 1;
                while (xCount >= 0 && yCount <= 7 && maxCount <= maxSpaces)
                {
                    if (gameBoard.Blocks[xCount, yCount].ChessPiece == null)
                    {
                        availableSpaces.Add(gameBoard.Blocks[xCount, yCount]);
                    }
                    else if (!gameBoard.Blocks[xCount, yCount].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                    {
                        availableSpaces.Add(gameBoard.Blocks[xCount, yCount]);
                        break;
                    }
                    else
                    {
                        break;
                    }

                    xCount--;
                    yCount++;
                    maxCount++;
                }
            }

            //check down/left
            if (x != 0 && y != 0)
            {
                xCount = x - 1;
                yCount = y - 1;
                while (xCount >= 0 && yCount >= 0 && maxCount <= maxSpaces)
                {
                    if (gameBoard.Blocks[xCount, yCount].ChessPiece == null)
                    {
                        availableSpaces.Add(gameBoard.Blocks[xCount, yCount]);
                    }
                    else if (!gameBoard.Blocks[xCount, yCount].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                    {
                        availableSpaces.Add(gameBoard.Blocks[xCount, yCount]);
                        break;
                    }
                    else
                    {
                        break;
                    }

                    xCount--;
                    yCount--;
                    maxCount++;
                }
            }

            //check down/right
            if (x != 7 && y != 0)
            {
                xCount = x + 1;
                yCount = y - 1;
                while (xCount <= 7 && yCount >= 0 && maxCount <= maxSpaces)
                {
                    if (gameBoard.Blocks[xCount, yCount].ChessPiece == null)
                    {
                        availableSpaces.Add(gameBoard.Blocks[xCount, yCount]);
                    }
                    else if (!gameBoard.Blocks[xCount, yCount].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                    {
                        availableSpaces.Add(gameBoard.Blocks[xCount, yCount]);
                        break;
                    }
                    else
                    {
                        break;
                    }

                    xCount++;
                    yCount--;
                    maxCount++;
                }
            }
            return availableSpaces;
        }

        public static void MakeMove(Board gameBaord, Block startBlock, Block endBlock)
        {
            if (endBlock.ChessPiece != null)
            {
                endBlock.ChessPiece.Alive = false;
                
            }
            endBlock.ChessPiece = startBlock.ChessPiece;
            startBlock.ChessPiece = null;
        }

        

        
           
    }
}
