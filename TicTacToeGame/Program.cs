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
            Console.WriteLine("Welocome to TicTacToe Game");
            CreatingBoard();
            TicTacToe ticTacToe = new TicTacToe();
            TicTacToe.Board(board);
        }
        /// <summary>
        /// Creatings the array of positions to be entered into array.
        /// </summary>
        /// <returns></returns>
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
