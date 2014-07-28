using BasicChess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Rules
{
    public class MoveManager
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

        //These methods are where special conditions are set before/after calling find strait and diagnal space methods
        //the knight method is the exception
        private static List<Block> FindAvaliableKnightSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces = new List<Block>();
            
            int x = currentBlock.X - 1;
            int y = currentBlock.Y - 1;
            //up 2 right 1
            if(x <= 6 && y<= 5)
            {
                if(gameBoard.Blocks[x+1, y+2].ChessPiece == null || !gameBoard.Blocks[x+1, y+2].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                {
                    availableSpaces.Add(gameBoard.Blocks[x + 1, y + 2]);
                }
            }
            //up 2 left 1
            if (x >= 1 && y <= 5)
            {
                if (gameBoard.Blocks[x - 1, y + 2].ChessPiece == null || !gameBoard.Blocks[x - 1, y + 2].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                {
                    availableSpaces.Add(gameBoard.Blocks[x - 1, y + 2]);
                }
            }
            //left 2 up 1
            if (x >= 2 && y <= 6)
            {
                if (gameBoard.Blocks[x - 2, y + 1].ChessPiece == null || !gameBoard.Blocks[x - 2, y + 1].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                {
                    availableSpaces.Add(gameBoard.Blocks[x - 2, y + 1]);
                }
            }
            //left 2 down 1
            if (x >= 2 && y >= 1)
            {
                if (gameBoard.Blocks[x - 2, y - 1].ChessPiece == null || !gameBoard.Blocks[x - 2, y - 1].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                {
                    availableSpaces.Add(gameBoard.Blocks[x - 2, y - 1]);
                }
            }
            //down 2 left 1
            if (x >= 1 && y >= 2)
            {
                if (gameBoard.Blocks[x - 1, y - 2].ChessPiece == null || !gameBoard.Blocks[x - 1, y - 2].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                {
                    availableSpaces.Add(gameBoard.Blocks[x - 1, y - 2]);
                }
            }
            //down 2 right 1
            if (x <= 6 && y >= 2)
            {
                if (gameBoard.Blocks[x + 1, y - 2].ChessPiece == null || !gameBoard.Blocks[x + 1, y - 2].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                {
                    availableSpaces.Add(gameBoard.Blocks[x + 1, y - 2]);
                }
            }
            //right 2 down 1
            if (x <= 5 && y >= 1)
            {
                if (gameBoard.Blocks[x + 2, y - 1].ChessPiece == null || !gameBoard.Blocks[x + 2, y - 1].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                {
                    availableSpaces.Add(gameBoard.Blocks[x + 2, y - 1]);
                }
            }
            //right 2 up 1
            if (x <= 5 && y <= 6)
            {
                if (gameBoard.Blocks[x + 2, y + 1].ChessPiece == null || !gameBoard.Blocks[x + 2, y + 1].ChessPiece.Color.Equals(currentBlock.ChessPiece.Color))
                {
                    availableSpaces.Add(gameBoard.Blocks[x + 2, y + 1]);
                }
            }
            return availableSpaces;
        }

        private static List<Block> FindAvaliableRookSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces = FindAvaliableStraitSpaces(gameBoard, currentBlock);
            return availableSpaces;
        }
        private static List<Block> FindAvaliableBishopSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces = FindAvaliableDiagonalSpaces(gameBoard, currentBlock);
            return availableSpaces;
        }
        private static List<Block> FindAvaliablePawnSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces = new List<Block>();
            List<Block> tempSpaces = null;
            if(currentBlock.ChessPiece.MaxMoves == 2)
            {
                currentBlock.ChessPiece.MaxMoves = 1;
            }
            if (currentBlock.ChessPiece.HasMoved == false)
            {
                currentBlock.ChessPiece.MaxMoves = 2;
            }
            tempSpaces = FindAvaliableStraitSpaces(gameBoard, currentBlock);
            
            //keep pawn from moving in reverse && sidways
            if (currentBlock.ChessPiece.PlayerId == 1)
            {
                foreach (Block space in tempSpaces)
                {
                    if (space.Y > currentBlock.Y)
                    {
                        availableSpaces.Add(space);
                    }
                }
            }
            else
            {
                foreach (Block space in tempSpaces)
                {
                    if (space.Y < currentBlock.Y)
                    {
                        availableSpaces.Add(space);
                    }
                }
            }

            //only add side moves if they are a attack
            tempSpaces = FindAvaliableDiagonalSpaces(gameBoard, currentBlock);
            if (currentBlock.ChessPiece.PlayerId == 1)
            {
                foreach (Block space in tempSpaces)
                {
                    if (space.Y > currentBlock.Y && space.Y == currentBlock.Y +1 && space.ChessPiece != null)
                    {
                        availableSpaces.Add(space);
                    }
                }
            }
            else
            {
                foreach (Block space in tempSpaces)
                {
                    if (space.Y < currentBlock.Y && space.Y == currentBlock.Y + 1 && space.ChessPiece != null)
                    {
                        availableSpaces.Add(space);
                    }
                }
            }


            return availableSpaces;
            
        }
        private static List<Block> FindAvaliableKingSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces = FindAvaliableStraitSpaces(gameBoard, currentBlock);
            availableSpaces.AddRange(FindAvaliableDiagonalSpaces(gameBoard, currentBlock));
            return availableSpaces;
        }
        private static List<Block> FindAvaliableQueenSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces = FindAvaliableStraitSpaces(gameBoard, currentBlock);
            availableSpaces.AddRange(FindAvaliableDiagonalSpaces(gameBoard, currentBlock));
            return availableSpaces;
        }



        //Basic available space methods
        private static List<Block> FindAvaliableStraitSpaces(Board gameBoard, Block currentBlock)
        {
            List<Block> availableSpaces = new List<Block>();
            int x = currentBlock.X -1;
            int y = currentBlock.Y -1;
            int maxSpaces = currentBlock.ChessPiece.MaxMoves;
            int maxCount = 1;
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
            maxCount = 1;
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
            maxCount = 1;
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
            maxCount = 1;
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
            int maxCount = 1;     
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
            maxCount = 1;
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
            maxCount = 1;
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
            maxCount = 1;
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
