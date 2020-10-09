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
            //for loop fills the empty positions in array which fills board.
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
            //Converting  a string to character.
            char characterToPlay = Convert.ToChar(Console.ReadLine().ToUpper());
            //Loop runs until correct character is entered.
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
        /// Adding the positions in array filled by user and cpu and displaying it on board.
        /// </summary>
        /// <param name="boardPositions">The board positions.</param>
        /// <param name="choosingCharacter">The choosing character.</param>
        /// <param name="tossResult">The toss result.</param>
        public static void MarkingPositions(char[] boardPositions, char[] choosingCharacter,int tossResult)
        {
            int checkForWin;
            int index = tossResult;
            //do while loop moves until game is drawn or any player wins.
            do
            {
                //switches input values between cpu and player one by one. Index value starts from toss result.
                switch (index % 2)
                {
                    //input by user.
                    case 0:
                        {
                            Console.WriteLine("Please enter the position between 1 to 9 where you want to fill your character");
                            while (true)
                            {

                                int positionEnteredByUser = Convert.ToInt32(Console.ReadLine());
                                if (positionEnteredByUser <= 9 && positionEnteredByUser >= 1)
                                {
                                    //if position in array and board is vacant, character is added.
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
                    // input done by user.
                    case 1:
                        {
                            //calling CpuMove method which processes input by cpu and enters in array and displays it on board.
                            TicTacToe.CpuMove(boardPositions, choosingCharacter, index);
                            break;
                        }
                    default:
                        break;

                }
               // calling CheckingForWinning method to see if game is ending or not.
                checkForWin = TicTacToe.CheckingForWinning(boardPositions);
                //if checkForWin ==0, one of the player has win the game.
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
                //if checkforWin= -1, than game is neither draw nor won by any player, positions are vacant in board.
            } while (checkForWin == -1);
        }
        /// <summary>
        /// Tosses for game.
        /// </summary>
        /// <returns> index whose mod is taken and passed to switch case statement.</returns>
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
        /// <summary>
        /// Checkings for winning.
        /// </summary>
        /// <param name="winningPositions">The winning positions.</param>
        /// <returns> returns 0 if game is win by any player, returns 1 if game is draw and -1 if game is continuing.</returns>
        public static int CheckingForWinning(char[] winningPositions)
        {
            //checking for horizontal positions
            if(winningPositions[1]==winningPositions[2] && winningPositions[2]==winningPositions[3] && winningPositions[1] !=' ')
            {
                return 0;

            }
            else if (winningPositions[4] == winningPositions[5] && winningPositions[5] == winningPositions[6] && winningPositions[4] !=' ')
            {
                return 0;

            }
            else if (winningPositions[7] == winningPositions[8] && winningPositions[8] == winningPositions[9] && winningPositions[7] != ' ')
            {
                return 0;

            }
            //checking for vertical positions
            else if (winningPositions[1] == winningPositions[4] && winningPositions[4] == winningPositions[7] && winningPositions[1] != ' ')
            {
                return 0;

            }
            else if (winningPositions[2] == winningPositions[5] && winningPositions[5] == winningPositions[8] && winningPositions[2] != ' ')
            {
                return 0;


            }
            else if (winningPositions[3] == winningPositions[6] && winningPositions[6] == winningPositions[9] && winningPositions[3] != ' ' )
            {
                return 0;

            }
            //checking for diogonal positions
            else if (winningPositions[1] == winningPositions[5] && winningPositions[5] == winningPositions[9] && winningPositions[1] != ' ' )
            {
                return 0;

            }
            else if (winningPositions[3] == winningPositions[5] && winningPositions[5] == winningPositions[7] && winningPositions[3] != ' ' )
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
        /// <summary>
        /// Cpus the move.
        /// </summary>
        /// <param name="boardPositions">The board positions.</param>
        /// <param name="choosingCharacter">The choosing character.</param>
        /// <param name="index">The index which helps in choosing character from array for cpu</param>
        public static void CpuMove(char[] boardPositions, char[] choosingCharacter, int index)
        {
            // while loop moves until position is entered by cpu in array and displayed in board.
            while (true)
            {
                int positionEnteredByCpu;
                int positionForWinning = CpuMoveForWinning(boardPositions, choosingCharacter);
                //if position for winning is 0, then their is no position at which cpu can win or block position for win of user.
                if (positionForWinning == 0)
                {
                    //calls the method to enter character at corner position, at middle and if no case is satisfied, randomly - by cpu.
                    positionEnteredByCpu = TicTacToe.FillingVoidPositionByCpu(boardPositions);
                }
                //calls the method and returns the value where either the cpu is winning or blocking position for winning of user.
                else
                {
                    positionEnteredByCpu = positionForWinning;
                }
                //adding character in array using position returned from methods and displaying in boards.
                if (boardPositions[positionEnteredByCpu] == ' ')
                {
                    boardPositions[positionEnteredByCpu] = choosingCharacter[index % 2];
                    TicTacToe.Board(boardPositions);
                    break;
                }
            }
        }
        /// <summary>
        /// Cpus the move for winning.
        /// </summary>
        /// <param name="boardPositions">The board positions.</param>
        /// <param name="choosingCharacter">The choosing character.</param>
        /// <returns> int which gives position of winning of cpu or either blocking of winning of user.</returns>
        public static int CpuMoveForWinning(char[] boardPositions, char[] choosingCharacter)
        {
            //returning the position of winning of cpu.
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
            //returning the position where cpu blocks the winning position of user.
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
        /// <summary>
        /// Fillings the void position by cpu.
        /// </summary>
        /// <param name="boardPositions">The board positions.</param>
        /// <returns>corner and mid position that can be filled by cpu </returns>
        public static int FillingVoidPositionByCpu(char[] boardPositions)
        {
            //list to add corner values.
            List<int> CpuPositionsList = new List<int>();
            for (int k = 1; k <= 9; k += 2)
            {
               
                if (k == 5)
                    continue;
                if (boardPositions[k] == ' ')
                {
                    CpuPositionsList.Add(k);
                }
            }
            Random random = new Random();
            //returns corner values.
            if (CpuPositionsList.Count > 0)
            {
                int SelectedIndexFromList = random.Next(CpuPositionsList.Count);
                return CpuPositionsList[SelectedIndexFromList];
            }
            //returns mid value.
            else if (boardPositions[5] == ' ')
                return 5;
            //returns random valus.
            else
            {
                return random.Next(1, 9);
            }

        }
    }
}

