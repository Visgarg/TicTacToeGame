using System;

namespace TicTacToeGame
{
    class Program
    {
        
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Welocome to TicTacToe Game");
            //Toss to decide, who will move, either computer or user.
            int tossResult = TicTacToe.TossForGame();
            //Array created for board positions
            char[] boardPositions= TicTacToe.CreatingBoard();
            //choosing character for player
            char[] charactersArray= TicTacToe.ChoosingCharacter();
            Console.WriteLine($"you will play with :{charactersArray[0]}");
            Console.WriteLine($"CPU will play with :{charactersArray[1]}");
            //displaying the board.
            TicTacToe.Board(boardPositions);
            //filling the values
            TicTacToe.MarkingPositions(boardPositions, charactersArray, tossResult);
        }

      
    }
}
