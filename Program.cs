using System;
using System.Collections;
using System.ComponentModel;

namespace ChessBoard
{
    internal class Program
    {
       //A method to write the board to the console
        static void BoardWriter(int boardSize,string[] boardArray)
        {
            Console.Write("  ");
            //writes the numbers for the columns on the top
            for (int i = 0; i < boardSize; i++)
                Console.Write(i + 1);
            //writes the first row identifier and adding a blankspace for formatting
            Console.Write("\n" + "A" + " ");

            //Writes the entire board
            //counter to make a new row when we reach the end of a row
            //if we reached that stage we make a new line and add 1 the row identifier which will result in B,C..
            int counter = 1;
            char Row = 'A';
            for (int i = 0; i < boardArray.Length; i++)
            {
                Console.Write(boardArray[i]);
                if (counter == boardSize)
                {
                    Console.Write("\n");
                    Row++;
                    //a final check to make sure we arent on the last row
                    if (i + 1 < boardArray.Length)
                        Console.Write(Row + " ");
                    counter = 1;
                    continue;
                }
                counter++;
            }

        }

        // A method to get Userinput for the symbols in the chessboard
        //returns a string 
        static string UserBoardSymbol()
        {
            Console.WriteLine("Välj en symbol");
            string symbol = Console.ReadLine();
            return symbol;
        }
        static string[] CreateBoard(int boardsize, string symbol1, string symbol2) //method för creating the board
        
        {
            //logic for creating the board

            string[] board = new string[(boardsize * boardsize)];
            int number = 0;
           
            for (int row = 0; row < boardsize; row++)
            {
                for(int column = 1; column <= boardsize; column++)
                {
                    // alternating between symbol1 or symbol2 depending on uneven or even number
                    board[number] = ((row + column) % 2 == 0) ? symbol1 : symbol2;
                    number++;
                    
                }
                
            }
            return board;
        }

        static void Main(string[] args)
        {
            //unicode to show the squares, and setting a unicode standard output
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            int boardSize = 0;

            //will loop while input is 0 or less or input "boardsize is higher then 10
            while (0 >= boardSize || 10 < boardSize)
            {
                Console.WriteLine("Mata in en Siffra! (1-10)"); // choose 10 as max becouse formatting issues with 2 characters when writing board
                int.TryParse(Console.ReadLine(), out boardSize);
               
            }
            string symbol1 = UserBoardSymbol();
            string symbol2 = UserBoardSymbol();
            string[] boardArray = CreateBoard(boardSize, symbol1, symbol2);

            BoardWriter(boardSize, boardArray);
            char userRow = (char)0;
            int userColumn = 0;
            //returns true if char number 65 is higher then row from user or if 'A' + total number of rows is equal or less then input
            while (65 > userRow || (65+boardSize) <= userRow )
            {
                
                Console.WriteLine("På vilken rad vill du placera din pjäs?");
                Console.WriteLine($"Rad A till {(char)('A'+(boardSize-1))}");
                char.TryParse(Console.ReadLine(), out userRow);
                
            }
            //returns true if 0 is higher or equal then input or if input is higher then boardsize
            while (0 >= userColumn || boardSize < userColumn)
            { 
                Console.WriteLine($"På vilken column vill du placera din pjäs 1-{boardSize}?");
                int.TryParse(Console.ReadLine(), out userColumn);
                
            }
            
            //since we know the order of the elements in the array we can use the ASCII number of userinput and column number
            //to figure out where we need to insert the new symbol
            // for example if the chessboard size is 5. Row A, column 5 will be at (0*5) + (5-1) = 4, index[4] since array starts at 0
            int intUserNumber = userRow - 65;
            intUserNumber = (intUserNumber * boardSize) + (userColumn-1);
            boardArray[intUserNumber] = "♞";
            Console.Clear();
            BoardWriter(boardSize, boardArray);
            Console.ReadLine();
            
        }
        
    }
}
    


        
    
    


