using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToe
    {
        public static char playerChar;
        public static char computerChar;
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
        public static void ChoosingCharacter()
        {
            Console.WriteLine("Please enter a character (X or O) to play");
            char characterToPlay = Convert.ToChar(Console.ReadLine());
            while (true)
            {
                if (characterToPlay != 'X' && characterToPlay != 'O')
                {
                    Console.WriteLine("you entered wrong character, please enter again");
                    characterToPlay = Convert.ToChar(Console.ReadLine());
                }
                else
                {
                    if (characterToPlay == 'X')
                    {
                        playerChar = characterToPlay;
                        computerChar = 'O';
                        break;
                    }
                    else
                    {
                        playerChar = 'O';
                        computerChar = 'X';
                        break;

                    }
                }
            }

        }

    }
}
