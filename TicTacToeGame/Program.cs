using System;

namespace TicTacToeGame
{
    class Program
    {
        public static char[] board = new char[10];
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main()
        {
            char[] charactersArray = new char[2];
            Console.WriteLine("Welocome to TicTacToe Game");
            CreatingBoard();
            //TicTacToe.Board(board);
            charactersArray= TicTacToe.ChoosingCharacter();
            Console.WriteLine($"you will play with :{charactersArray[0]}");
            Console.WriteLine($"CPU will play with :{charactersArray[1]}");
        }
        /// <summary>
        /// Creatings the array of positions to be entered into array.
        /// </summary>
        /// <returns> empty positions for board in array</returns>
        public static char[] CreatingBoard()
        {
            for (int k = 0; k < board.Length; k++)
            {
                board[k] = ' ' ;
            }
            return board;

        }
    }
}
