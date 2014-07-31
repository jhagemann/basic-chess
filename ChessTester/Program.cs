﻿using BasicChess.Models;
using BasicChess.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTester
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Game chessGame = new Game("Jared", "Blue", "Jen", "Pink");
            chessGame.SetUpBoard();
            MoveManager.MakeMove(chessGame, chessGame.GameBoard.Blocks[0,1], chessGame.GameBoard.Blocks[0,3]);
            List<Block> blocks = MoveManager.FindAvailableMoveSpaces(chessGame.GameBoard, chessGame.GameBoard.Blocks[3, 4]);
            Console.Write(chessGame.GameBoard.ToString());
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(chessGame.GameBoard.ScopePrint());
            Console.Read();
             * */
            Console.WriteLine("Welcome to Basic Chess, please press any key to continue");
            Console.ReadLine();
            Console.WriteLine("Please Enter Player 1's name:");
            String p1 = Console.ReadLine();
            Console.WriteLine("Welcome " + p1 + ", please enter Player 2's name:");
            String p2 = Console.ReadLine();
            Console.WriteLine("Welcome " + p2);
            Console.WriteLine("...Initiating Game...");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Game chessGame = new Game(p1, "White", p2, "Black");
            chessGame.SetUpBoard();
            bool player1Turn = true;
            bool isValidChoice = false;
            while (chessGame.Players[0].IsWinner == false && chessGame.Players[1].IsWinner == false)
            {
                int player = player1Turn ? 1 : 2;
                Console.WriteLine(chessGame.GameBoard.ToString());
                Console.WriteLine("It is player " + player + "'s turn");
                Console.WriteLine("Please choose a piece to move by location (ex. a1 or d5):");
                String pieceChoice = Console.ReadLine();
                isValidChoice = MoveAuthenticator.IsValidPieceChoice(chessGame, player1Turn, pieceChoice);
                while (!isValidChoice)
                {
                    Console.WriteLine("This is not a valid choice, please choose again (ex. a1 or d5):");
                    pieceChoice = Console.ReadLine();
                    isValidChoice = MoveAuthenticator.IsValidPieceChoice(chessGame, player1Turn, pieceChoice);                    
                }
                Block startBlock = chessGame.GameBoard.FindBlock(pieceChoice);
                Console.WriteLine("You chose to move your " + startBlock.ChessPiece.Name + ".  Select space to move to...");
                List<Block> choices = MoveManager.FindAvailableMoveSpaces(chessGame.GameBoard, startBlock);
                String choiceString = "";
                foreach (Block space in choices)
                {
                    choiceString += space.Name() + ", ";
                }

                Console.WriteLine("Your choices are " + choiceString);
                String moveChoice = Console.ReadLine();
                isValidChoice = MoveAuthenticator.IsValidMoveChoice(chessGame, startBlock, moveChoice);
                while (!isValidChoice)
                {
                    Console.WriteLine("This is not a valid choice, please choose again (ex. a1 or d5):");
                    Console.WriteLine("Your choices are " + choiceString);
                    moveChoice = Console.ReadLine();
                    isValidChoice = MoveAuthenticator.IsValidMoveChoice(chessGame, startBlock, moveChoice);
                }
                Block endBlock = chessGame.GameBoard.FindBlock(moveChoice);
                MoveManager.MakeMove(chessGame, startBlock, endBlock);
                player1Turn = player1Turn ? false : true;
                
            }
        }

        

        
    }
}
