﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToe
    {

        /// <summary>
        /// Boards the specified board positions.
        /// </summary>
        /// <param name="boardPositions">The board positions is a character array</param>
        public static void Board(char[] boardPositions)
        {
            // this method posts the board.
            Console.WriteLine("Below is the board of TicTacToe"); 
            Console.WriteLine($"{boardPositions[1]} | {boardPositions[2]} |{ boardPositions[3]}");
            Console.WriteLine("__|___|__");
            Console.WriteLine($"{boardPositions[4]} | {boardPositions[5]} | { boardPositions[6]}");
            Console.WriteLine("__|___|__");
            Console.WriteLine($"{boardPositions[7]} | {boardPositions[8]} | { boardPositions[9]}");
        }

    }
}
