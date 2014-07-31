using BasicChess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicChess.Rules
{
    public class MoveAuthenticator
    {  
        //simply validates the input is a space on the board
        public static bool IsValidSpace(Game game, String choice)
        {
            bool valid = false;
            if(choice.Length !=2)
            {
                return valid;
            }

            if(!Board.xDictionary.ContainsKey(choice.Substring(0,1)))
            {
                return valid;
            }
            
            int y;
            if(!int.TryParse(choice.Substring(1,1), out y))
            {
                return valid;
            }
            
            if(y > 0 && y <=8)
            {
                valid = true;
            }
            return valid;
        }

        //validates that the space that was chosen contians a piece belonging to that player
        public static bool IsValidPieceChoice(Game game, bool player1Turn, String choice)
        {
            bool valid = false;

            if (!IsValidSpace(game, choice))
            {
                return valid;
            }

            Block block = game.GameBoard.FindBlock(choice);

            if (block.ChessPiece == null)
            {
                return valid;
            }

            if (block.ChessPiece.PlayerId == 1 && player1Turn)
            {
                valid = true;
            }
            else if (block.ChessPiece.PlayerId == 2 && !player1Turn)
            {
                valid = true;
            }
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
            Block endBlock = game.GameBoard.FindBlock(choice);

            List<Block> moves = MoveManager.FindAvailableMoveSpaces(game.GameBoard, startBlock);
            if (moves.Contains(endBlock))
            {
                valid = true;
            }
            return valid;
        }
    }
}
