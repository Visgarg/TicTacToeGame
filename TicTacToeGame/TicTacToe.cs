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
        public static void MarkingPositions(char[] boardPositions, char[] choosingCharacter,int tossResult)
        {
            int checkForWin;
            int index = tossResult;
            do
            {
                switch (index % 2)
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
                            TicTacToe.CpuMove(boardPositions, choosingCharacter, index);
                            break;
                        }
                    default:
                        break;

                }
               
                checkForWin = TicTacToe.CheckingForWinning(boardPositions);
                if (checkForWin == 0)
                {
                    if (index % 2 == 0)
                    {
                        Console.WriteLine("You have won the game");
                    }
                    else
                    {
                        Console.WriteLine("Cpu has won the game");
                    }
                    break;
                }
                index++;
            } while (checkForWin == -1);
        }
        public static int TossForGame()
        {
            //creating the method for having a toss using random function.
            Random random = new Random();
            int index = random.Next(0,2);
            if(index==0)
            {
                Console.WriteLine("You won the toss, you will be doing the first move");
            }
            else
            {
                Console.WriteLine("you have loss the toss, computer will have the first move");
            }
            return index;
        }
        public static int CheckingForWinning(char[] winningPositions)
        {
            //checking for horizontal positions
            if(winningPositions[1]==winningPositions[2] && winningPositions[2]==winningPositions[3] && winningPositions[1] !=' '&& winningPositions[2] != ' ' && winningPositions[3] != ' ')
            {
                return 0;

            }
            else if (winningPositions[4] == winningPositions[5] && winningPositions[5] == winningPositions[6] && winningPositions[4] != ' ' && winningPositions[5] != ' ' && winningPositions[6] != ' ')
            {
                return 0;

            }
            else if (winningPositions[7] == winningPositions[8] && winningPositions[8] == winningPositions[9] && winningPositions[7] != ' ' && winningPositions[8] != ' ' && winningPositions[9] != ' ')
            {
                return 0;

            }
            //checking for vertical positions
            else if (winningPositions[1] == winningPositions[4] && winningPositions[4] == winningPositions[7] && winningPositions[1] != ' ' && winningPositions[4] != ' ' && winningPositions[7] != ' ')
            {
                return 0;

            }
            else if (winningPositions[2] == winningPositions[5] && winningPositions[5] == winningPositions[8] && winningPositions[2] != ' ' && winningPositions[5] != ' ' && winningPositions[8] != ' ')
            {
                return 0;


            }
            else if (winningPositions[3] == winningPositions[6] && winningPositions[6] == winningPositions[9] && winningPositions[3] != ' ' && winningPositions[6] != ' ' && winningPositions[9] != ' ')
            {
                return 0;

            }
            //checking for diogonal positions
            else if (winningPositions[1] == winningPositions[5] && winningPositions[5] == winningPositions[9] && winningPositions[1] != ' ' && winningPositions[5] != ' ' && winningPositions[9] != ' ')
            {
                return 0;

            }
            else if (winningPositions[3] == winningPositions[5] && winningPositions[5] == winningPositions[7] && winningPositions[3] != ' ' && winningPositions[5] != ' ' && winningPositions[7] != ' ')
            {
                return 0;

            }
            else if(winningPositions[1] !=' ' && winningPositions[2] != ' ' && winningPositions[3] != ' ' && winningPositions[4] != ' ' && winningPositions[5] != ' '&& winningPositions[6] != ' ' && winningPositions[7]!= ' ' && winningPositions[8] != ' ' && winningPositions[9] != ' ')
            {
                Console.WriteLine("Game Draw, no one won the match");
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public static void CpuMove(char[] boardPositions, char[] choosingCharacter, int index)
        {
            Random random = new Random();
            List<int> CpuPositionsList = new List<int>();
            while (true)
            {
                int positionEnteredByCpu;
                int positionForWinning = CpuMoveForWinning(boardPositions, choosingCharacter);
                if (positionForWinning == 0)
                {
                    positionEnteredByCpu = random.Next(1, 10);
                }
                else
                {
                    positionEnteredByCpu = positionForWinning;
                }
                if (boardPositions[positionEnteredByCpu] == ' ')
                {
                    CpuPositionsList.Add(positionEnteredByCpu);
                    boardPositions[positionEnteredByCpu] = choosingCharacter[index % 2];
                    TicTacToe.Board(boardPositions);
                    break;
                }
            }
        }
        public static int CpuMoveForWinning(char[] boardPositions, char[] choosingCharacter)
        {
            for (int i= 1;i<= 9;i++)
            {
                if(boardPositions[i]==' ')
                {
                    boardPositions[i] = choosingCharacter[1];
                    if(TicTacToe.CheckingForWinning(boardPositions)==0)
                    {
                        boardPositions[i] = ' ';
                        return i;
                    }
                    boardPositions[i] = ' ';
                }
            }
            for (int j = 1; j <= 9; j++)
            {
                if (boardPositions[j] == ' ')
                {
                    boardPositions[j] = choosingCharacter[0];
                    if (TicTacToe.CheckingForWinning(boardPositions) == 0)
                    {
                        boardPositions[j] = ' ';
                        return j;
                    }
                    boardPositions[j] = ' ';
                }
            }
            return 0;

        }
    }
}

