using System;

namespace TicTacToeGame
{
    class Program
    {
        public static char[] board = new char[10];
        static void Main(string[] args)
        {
            Console.WriteLine("Welocome to TicTacToe Game");
            CreatingBoard();
            TicTacToe ticTacToe = new TicTacToe();
            TicTacToe.Board(board);
        }
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
