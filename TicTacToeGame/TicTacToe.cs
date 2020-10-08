using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToe
    {
        public static char[] board = new char[10];
        public static char playerChar;
        public static char computerChar;

        /// <summary>
        /// Creatings the array of positions to be entered into array.
        /// </summary>
        /// <returns> empty positions for board in array</returns>
        public static char[] CreatingBoard()
        {
            for (int k = 0; k < board.Length; k++)
            {
                board[k] = ' ';
            }
            return board;
        }
        /// <summary>
        /// Choosings the character.
        /// </summary>
        /// <returns>characters of player and cpu in array.</returns>
        public static char[] ChoosingCharacter()
        {
            Console.WriteLine("Please enter a character (X or O) to play");
            char[] arrayOfCharacters = new char[2];
            char characterToPlay = Convert.ToChar(Console.ReadLine().ToUpper());
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
                        playerChar = 'X';
                        Console.WriteLine("Character has been accepted");
                        computerChar = 'O';
                        break;
                    }
                    else
                    {
                        playerChar = 'O';
                        Console.WriteLine("Character has been accepted");
                        computerChar = 'X';
                        break;

                    }
                    
                }
            }
            arrayOfCharacters[0] = playerChar;
            arrayOfCharacters[1] = computerChar;
            return arrayOfCharacters;

        }
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
        /// <summary>
        /// The position is entered by user and displayed in board.
        /// </summary>
        /// <param name="boardPositions">The board positions.</param>
        /// <param name="choosingCharacter">The choosing character.</param>
        public static void MarkingPositions(char[] boardPositions, char[] choosingCharacter)
        {
            int index = TicTacToe.TossForGame();
            do
            {
               switch(index%2)
                {
                    case 0:
                    {
                        Console.WriteLine("Please enter the position between 1 to 9 where you want to fill your character");
                        while (true)
                        {

                            int positionEnteredByUser = Convert.ToInt32(Console.ReadLine());
                            if (positionEnteredByUser <= 9 && positionEnteredByUser >= 1)
                            {
                                if (boardPositions[positionEnteredByUser] == ' ')
                                {
                                    boardPositions[positionEnteredByUser] = choosingCharacter[index % 2];
                                    TicTacToe.Board(boardPositions);
                                    break;
                                }
                                else
                                {
                                Console.WriteLine("The position is already occupied, please enter position again");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Please enter the correct position to fill");
                            }
                        }
                        break;
                    }
                    case 1:
                    {
                        Random random = new Random();
                        
                        while (true)
                        {
                                int positionEnteredByCpu = random.Next(1, 10);
                                if (positionEnteredByCpu <= 9 && positionEnteredByCpu >= 1)
                                {
                                    if (boardPositions[positionEnteredByCpu] == ' ')
                                    {
                                        boardPositions[positionEnteredByCpu] = choosingCharacter[index % 2];
                                        TicTacToe.Board(boardPositions);
                                        break;
                                    }
                                }
                        }
                        break;
                   
                    }
                    default:
                        break;

               }
                index++;
            } while (boardPositions[1]==' ' || boardPositions[2] == ' ' || boardPositions[3] == ' ' || boardPositions[4] == ' ' || boardPositions[5] == ' ' || boardPositions[6] == ' ' || boardPositions[7]  == ' ' || boardPositions[8] == ' ' || boardPositions[9] == ' ');
        }
        public static int TossForGame()
        {
            //creating the method for having a toss using random function.
            Random random = new Random();
            int index = random.Next(0,2);
            return index;
        }
        }
    }

