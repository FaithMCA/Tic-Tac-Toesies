
using System;
using System.Runtime.CompilerServices;

namespace Tic_Tac_Toesies {
    internal class Program {

        static void CheckFreeSpaces() {

        }
        static void Main(string[] args) {
            int[] move = PlayerMove(true);
            //VARIABLES
            bool playerX = true;
;
            int winner  = ' ';

            char[,] board     = { { '\0', '\0', '\0' }, 
                                  { '\0', '\0', '\0' }, 
                                  { '\0', '\0', '\0' } };

            char symbol  = ' ';
            int xPos     = 1;
            int yPos     = 2;

            ResetBoard(board);


            while (winner == ' ' || winner == '\0') {


                DrawBoard();
                PlayerXTurn(true);
                PlayerMove(true);
                PlaceMarker(board, symbol, xPos, yPos);
                WinCheck(board);
                PlayerXTurn(false);



            }//end while loop

            //DISPLAYS THE TIC-TAC TOE BOARD ON CONSOLE.
            DrawBoard();


            //DISPLAYS THE SYMBOLS IN THE BOARD ARRAY ON THE CONSOLE. 
            DrawSymbols(board);


            //DISPLAYS A SINGLE SYMBOL X OR O ON THE CONSOLE AT A POSITION.



            //ALLOWS CHANGING THE BOARD DATA BY PLACING A SYMBOL IN A LOCATION THE ARRAY.
            //THIS FUNCTION RETURNS A BOOL THAT REPRESENTS IF THE MARKER CAN BE PLACED THERE.
            PlaceMarker(board, symbol,xPos, yPos);
            DrawSymbols(board);

            //Console.ReadLine();
            //Console.Clear();

            //DrawBoard();
            //DrawSymbols(board);
            //DETERMINES WHETHER A PLAYER HAS WON OR IF A TIE HAS OCCURED. IF A PLAYER HAS WON
            //THE PROGRAM SHOULD DECLARE THAT PLAYER THE WINNER AND END. IF A TIE HAS OCCURED,
            //THE PROGRAM SHOULD SAY SO AND END.



            Console.Write(" ");
            Console.Read();

        }//end main


        static void DrawBoard() {

            //Draw Legs of Board
            byte[] WHITE = { 200, 200, 200 };

            for (int index = 0; index < 17; index++) {
                ConsoleSetBlock(5, index,  WHITE);
                ConsoleSetBlock(index, 5,  WHITE);
                ConsoleSetBlock(11, index, WHITE);
                ConsoleSetBlock(index, 11, WHITE);
            }//end for

        }//end DrawBoard function


        static void DrawSymbols(char[,] board) {//BOARD ARRAY IS WHERE YOU'RE ACTUALLY STORING THE X OR O SYMBOL IN ITS 3 BY 3 LOCATION

            int posX = 1;
            int posY = 1;   

            for (int indexX = 0; indexX < board.GetLength(0); indexX++) {
                for (int indexY = 0; indexY < board.GetLength(1); indexY++) {
                    char symbol = board[indexX, indexY];
                    DrawSymbol(symbol, posX, posY);
                    posX += 6;
                   

                }//end nested for
                posX = 1;
                posY += 6;
            }//end for

            //--------------------------------------------------------
            //   NOTES BELOW JUST TO KEEP UP WITH THE COORDINATES
            //--------------------------------------------------------
                //DrawSymbol(board[0, 0], 2, 2);
                //DrawSymbol(board[0, 1], 8, 2);
                //DrawSymbol(board[0, 2], 14, 2);

                //DrawSymbol(board[1, 0], 2, 8);
                //DrawSymbol(board[1, 1], 8, 8);
                //DrawSymbol(board[1, 2], 14, 8);

                //DrawSymbol(board[2, 0], 2, 14);
                //DrawSymbol(board[2, 1], 8, 14);
                //DrawSymbol(board[2, 2], 14, 14);
            //----------------------------------------------------------

        }//end DrawSymbols function

        static void DrawSymbol(char symbol, int xPos, int yPos) { 

                    byte[] BLUE = { 102, 217, 255 };

                if (symbol == 'x' || symbol == 'X') {
                    ConsoleSetBlock(0 + xPos, 0 + yPos, BLUE);
                    ConsoleSetBlock(0 + xPos, 2 + yPos, BLUE);
                    ConsoleSetBlock(1 + xPos, 1 + yPos, BLUE);
                    ConsoleSetBlock(2 + xPos, 0 + yPos, BLUE);
                    ConsoleSetBlock(2 + xPos, 2 + yPos, BLUE);
                }//end if


                    byte[] RED = { 255, 102, 102 };

                if (symbol == 'o' || symbol == 'O') {
                    ConsoleSetBlock(0 + xPos, 0 + yPos, RED);
                    ConsoleSetBlock(0 + xPos, 1 + yPos, RED);
                    ConsoleSetBlock(0 + xPos, 2 + yPos, RED);
                    ConsoleSetBlock(1 + xPos, 0 + yPos, RED);
                    ConsoleSetBlock(1 + xPos, 2 + yPos, RED);
                    ConsoleSetBlock(2 + xPos, 0 + yPos, RED);
                    ConsoleSetBlock(2 + xPos, 1 + yPos, RED);
                    ConsoleSetBlock(2 + xPos, 2 + yPos, RED);
                }//end if

            }//end DrawSymbol function


        static bool PlaceMarker(char[,] board, char symbol, int xSlot, int ySlot) {           


                    if ('x' == board[xSlot,ySlot] || 'X' == board[xSlot, ySlot] || 'o' == board[xSlot, ySlot] || 'O' == board[xSlot, ySlot]) {
                        Console.WriteLine("Cannot place symbol here");
                        return false;
                    } else if (board[xSlot,ySlot] == ' '|| board[xSlot,ySlot] == '\0') {
                        board[xSlot, ySlot] = symbol;
                    }//end if              
        

            return true;

        } //end PlaceMarker function

        static int CheckSymbol(char symbol) {
            if (symbol == 'x') {
                return 1;
            } else if (symbol == 'o') {
                return 2;
            }
            else { return 0; }
        }//end CheckSymbol function

        static int WinCheck(char[,] board) {

            int noResults = 0;
            int playerX   = 1;
            int playerO   = 2;
            int tie       = 3;

            //checking all the slots in the board
            for (int index = 0; index < 3; index++) {

                //check rows     X 
                if (board[index, 0] == board[index, 1] && board[index, 0] == board[index, 2]) {

                    return CheckSymbol(board[index, 0]);
                }//end if

                //check columns  Y 
                if (board[0, index] == board[1, index] && board[0, index] == board[2, index]) {

                    return CheckSymbol(board[0, index]);
                }//end if

                //check diagonals
                if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) {

                    return CheckSymbol(board[0, 0]);
                }//end nested if

                if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]) {

                    return CheckSymbol(board[0, 2]);

                    //CHECK SYMBOL FUNCTION EXAMPLE:
                    //if (board[0, 2] == 'x') {
                    //return playerX;

                    //} else if (board[0, 2] == 'o') {
                    //return playerO;

                    //}//end nested if

                }//end if
            }

            return 0;
                
        }//end WinCheck function


        static void ResetBoard(char[,] board) {

            for(int indexX = 0; indexX < 3; indexX++) {
                for(int indexY = 0; indexY < 3; indexY++) {
                    board[indexX, indexY] = ' ';
                }//end nested for loop
            }//end for loop

        }//end ResetBoard function

        static int[] PlayerMove(bool playerTurn) {

            string playerInput = "";
            int[] position = {-1,-1};

            //"0 0"
            playerInput = Input("Please, first enter the Row Number (1 - 3), then the Column Number (1 - 3): ");

            string[] positionString = playerInput.Split(' ');
            //"0" "0
            for(int index = 0; index < positionString.Length; index++) {
                bool canParse = false;
                do {
                    canParse = int.TryParse(positionString[index], out position[index]);
                    
                    //Gives chance to fix input
                    if (canParse == false) {
                        playerInput = Input("WRONG, first enter the Row Number (1 - 3), then the Column Number (1 - 3): ");

                        positionString = playerInput.Split(' ');
                    }
                } while (canParse == false);
            }
            
            
            //0    0 
            //assign x pos
           

            return pos;

        }//end PlayerMove

        static bool PlayerXTurn(bool playerX = true) {          

            if (playerX != playerX) {
            }

            return false;

        }//end PlayerTurn function



        #region HELPER DRAWING FUNCTIONS 

        static void ConsoleSetForeColor(byte red, byte grn, byte blu) {
            Console.Write($"\x1b[38;2;{red};{grn};{blu}m");
        }//end ConsoleSetForecolor function

        static void ConsoleSetBackColor(byte red, byte grn, byte blu) {
            Console.Write($"\x1b[48;2;{red};{grn};{blu}m");
        }//end ConsoleSetBackColor function

        static void ConsoleSetBlock(int xPos, int yPos, byte[] color) {
            //STORE OLD COLORS
            ConsoleColor origForeground = Console.ForegroundColor;
            ConsoleColor origBackground = Console.BackgroundColor;

            //SET BLOCK COLOR
            byte red = color[0];
            byte grn = color[1];
            byte blu = color[2];

            ConsoleSetForeColor(red, grn, blu);
            ConsoleSetBackColor(red, grn, blu);

            //MOVE CURSOR TO POSITION
            Console.SetCursorPosition(xPos, yPos);

            //DRAW BLOCK
            Console.Write(" ");

            //CHANGE COLORS BACK
            Console.ForegroundColor = origForeground;
            Console.BackgroundColor = origBackground;
        }//end ConsoleSetBlock function

        #endregion


        #region HELPER FUNCTION

        static string Input(string message) {

            Console.Write(message);
            return Console.ReadLine();

        }//end Input function

        static decimal InputDecimal(string message) {

            string value = Input(message);
            return decimal.Parse(value);

        }//end InputDecimal function

        static double InputDouble(string message) {

            string value = Input(message);
            return double.Parse(value);

        }//end InputDouble function

        static int InputInt(string message) {

            string value = Input(message);
            return int.Parse(value);

        }//end InputInt function

        static int TryInputInt(string message) {

            //VARIABLES
            int parsedValue = 0;
            bool gotParsed = false;

            //VALIDATION LOOP UNTIL VALID INT HAS BEEN SUBMITTED
            do {
                gotParsed = int.TryParse(Input(message), out parsedValue);
                
            } while (gotParsed == false);

            //RETURN PARSED VALUE
            return parsedValue;

        }//end TryInputInt function

        static double TryInputDouble(string message) {

            //VARIABLES
            double parsedValue = 0;
            bool gotParsed = false;

            //VALIDATION LOOP UNTIL VALID INT HAS BEEN SUBMITTED
            do {
                gotParsed = double.TryParse(Input(message), out parsedValue);
            } while (gotParsed == false);

            //RETURN PARSED VALUE
            return parsedValue;

        }//end TryInputDouble function

        #endregion


    }//end class
}//end namespace