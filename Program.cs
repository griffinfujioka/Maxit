using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Maxit; 

namespace Maxit
{
    #region Use static helper class for random number generation 
    public static class StaticRandom
    {
        private static int seed;

        private static ThreadLocal<Random> threadLocal = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        static StaticRandom()
        {
            seed = Environment.TickCount; 
        }

        public static Random Instance { get { return threadLocal.Value; } }
    }
    #endregion 

    class Program
    {
        #region findAvailableSelection
        public static void findAvailableSelection(int[,] array, int size, ref int row, ref int column)
        {
            int i, j;
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (array[i, j] != 'X')
                    {
                        row = i;
                        column = j;
                        return; 
                    }
                }
            }
        }
        #endregion

        #region rowIsEmpty
        public static bool rowIsEmpty(int[,] array, int size, int row)   // return -1 if row is empty or the index of the remaining number
        {
            int i; 
            for (i = 0; i < size; i++)
            {
                if (array[row, i] != 'X')
                    return false; 
            }
            return true; 
        }
        #endregion 

        #region columnIsEmpty
        public static bool columnIsEmpty(int[,] array, int size, int column)   // return -1 if column is empty or the index of the remaining number
        {
            int i; 
            for(i=0; i<size; i++)
            {
                if(array[i,column] != 'X')
                    return false; 
            }
            return true; 
        }
        #endregion 

        #region boardIsEmpty - check to see if all coordinates have been selected
        public static bool boardIsEmpty(int N, int[,] array)
        {
            // After coordinate (i.e., [3,2]) is selected, it's value is changed to 'X'
                // So check each cell to see if it is NOT an 'X', thus signifying that the game is not over. 
            #region Look for a valid number in the game grid 
            int i, j;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    if (array[i, j] != 'X')
                        return false; 
                }

            }
            return true; 
            #endregion 
        }
        #endregion 

        #region getCPUSelection - get the selection of the CPU based on a simple selection algorithm 
        public static void getCPUSelection(int N, int[,] array, ref int rowSelection, ref int columnSelection, int lastSelectedRow, int lastSelectedColumn)
        {
            
            // Look for the maximum value in the grid but must be in lastSelectedRow or lastSelectedColumn - Must select from current row and column 
            int i, max = -10;   // max initially (lowest possible number - 1) = (-9 - 1)
            int row=0, column=0;
            for (i = 0; i < N; i++)
            {
                if (array[lastSelectedRow, i] > max && array[lastSelectedRow, i] != 'X')
                {
                    max = array[lastSelectedRow,i];
                    row = lastSelectedRow;
                    column = i; 
                }
            }

            for (i = 0; i < N; i++)
            {
                if (array[i, lastSelectedColumn] > max && array[i, lastSelectedColumn] != 'X')
                {
                    max = array[i, lastSelectedColumn];
                    row = i;
                    column = lastSelectedColumn;
                }
            }
            
            rowSelection = row;
            columnSelection = column; 
            return; 
        }
        #endregion 
 

        #region Print score
        public static void printScore(int userScore, int computerScore)
        {
            Console.WriteLine("\n-------- Scoreboard --------"); 
            Console.WriteLine("User: " + userScore + " points");
            Console.WriteLine("CPU: " + computerScore + " points");
            Console.WriteLine("----------------------------\n");

        }
        #endregion 

        #region printGrid(int size, int[,] array, int lastSelectedRow, int lastSelectedColumn)
        public static void printGrid(int size, int[,] array, int lastSelectedRow, int lastSelectedColumn)
        {
            int N = size;
            int i,j;
            Console.WriteLine("Last selection: [" + lastSelectedRow + "," + lastSelectedColumn + "]"); 
            #region Print numbers for top 
            Console.Write("   "); 
            for (i = 0; i < N; i++)
                Console.Write(i + "\t");
            Console.Write("\n");
            Console.Write("   ");
            for (i = 0; i < N; i++)
                Console.Write("-\t"); 
            #endregion 

            Console.Write("\n"); 

            // Bug: If the entire row is empty, find the first entry in the 2D array and put it there
            #region Print rows of numbers
            for (i = 0; i < N; i++)
            {
                Console.Write(i + "| ");   // Write the row number 

                for (j = 0; j < N; j++)
                {
                    if (array[i, j] == 'X')
                    {
                        
                        if (i == lastSelectedRow && j == lastSelectedColumn)
                        {
                            Console.Write("X<--\t");

                        }
                        else
                        {
                            Console.Write("X\t");
                        }
                    }
                    else
                    {
                        
                        if (i == lastSelectedRow && j == lastSelectedColumn)
                        {
                            Console.Write(array[i, j] + "<--\t");
                        }
                        else
                        {
                            Console.Write(array[i, j] + "\t");
                        }
                    }
                    
                }

                Console.Write("\n"); 
                

            }
            #endregion 
        }
        #endregion 

        #region printGrid override: Pass in last selected location to and put indicating '<--' next to that location 
        //public static void printGrid(int size, int[,] array, int foundRow, int foundColumn)
        //{
        //    int N = size;
        //    int i, j;
        //    Console.WriteLine("Last selection: [" + foundRow + "," + foundColumn + "]");
        //    #region Print numbers for top
        //    Console.Write("   ");
        //    for (i = 0; i < N; i++)
        //        Console.Write(i + "\t");
        //    Console.Write("\n");
        //    Console.Write("   ");
        //    for (i = 0; i < N; i++)
        //        Console.Write("-\t");
        //    #endregion

        //    Console.Write("\n");

        //    // Bug: If the entire row is empty, find the first entry in the 2D array and put it there
        //    #region Print rows of numbers
        //    for (i = 0; i < N; i++)
        //    {
        //        Console.Write(i + "| ");   // Write the row number 

        //        for (j = 0; j < N; j++)
        //        {
        //            if (array[i, j] == 'X')
        //            {

        //                if (i == foundRow && j == foundColumn)
        //                {
        //                    Console.Write("X<--\t");

        //                }
        //                else
        //                {
        //                    Console.Write("X\t");
        //                }
        //            }
        //            else
        //            {

        //                if (i == foundRow && j == foundColumn)
        //                {
        //                    Console.Write(array[i, j] + "<--\t");
        //                }
        //                else
        //                {
        //                    Console.Write(array[i, j] + "\t");
        //                }
        //            }

        //        }

        //        Console.Write("\n");


        //    }
        //    #endregion
        //}
        #endregion 

        #region Generate a random start point 
        public static void initializeStartPoint(ref int row, ref int column, int N)
        {
            row = StaticRandom.Instance.Next(0, N);
            column = StaticRandom.Instance.Next(0, N);
            Console.WriteLine("Initial position is [" + row + "," + column + "]\n"); 
        }
        #endregion 

        static void Main(string[] args)
        {
            System.Console.Write("Welcome to Maxit!\n\n");

            #region Variable declarations
            int N = 0;
            bool humanTurn = true;
            int userScore = 0, computerScore = 0;
            int lastSelectedRow=0, lastSelectedColumn=0;
            int initialRow=0, initialColumn=0;
            bool emptyRow = false;
            bool emptyColumn = false;
            int rowSelection=0, columnSelection=0;
            string line;
            int value = 0;
            bool gameIsOver = false; 
            #endregion 

            #region Run in test mode?
            Console.WriteLine("Run in test mode? (y/n)"); 
            System.ConsoleKeyInfo KInfo = Console.ReadKey(true); 
            if(KInfo.KeyChar == 'y')
                Maxit.TestDrivers.main(args);
            #endregion 

            #region Get size of the grid
            Console.WriteLine("Enter size of grid (N x N): ");
            string sizeEntry = Console.ReadLine();
            if (sizeEntry == null)      // Something went terribly wrong? 
                Console.WriteLine("Error: Could not read line\n");
            
            bool isNumeric = int.TryParse(sizeEntry, out N);        // N now = numeric value, isNumeric = false -> Not a numeric value 

            while (!isNumeric)
            {
                Console.WriteLine("Please enter a numeric value.");
                sizeEntry = Console.ReadLine();
                isNumeric = int.TryParse(sizeEntry, out N);
            
            }

            //Console.WriteLine("Thank you for writing a numeric value. N is " + N + "."); 
            #endregion 

            #region Initialize array, initial position 
            int[,] array = new int[N, N];       // Now we can create an array for the game. 
            initializeStartPoint(ref initialRow, ref initialColumn, N);
            lastSelectedRow = initialRow;
            lastSelectedColumn = initialColumn;
            #endregion

            #region Determine the 0-indexes of the grid. (N-1)
            int bound0 = array.GetUpperBound(0);    // bound0 = N-1
            int bound1 = array.GetUpperBound(1);    //  = bound1 = N-1
            //Console.WriteLine("The 0-based size of the grid is " + bound0 + ".\n\n"); 
            #endregion 
            
            #region Populate array with random numbers
            // We need to populate the arrays with random integers ranging from -9 to 15
            int i, j;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    int randomNumber = StaticRandom.Instance.Next(-9, 15); 
                    array[i, j] = randomNumber;
                    //Console.WriteLine("array[" + i + "][" + j + "] is " + randomNumber);
                }

            }
            #endregion 

            printGrid(N, array, lastSelectedRow, lastSelectedColumn);    // Print the initial grid 

            #region Game loop 
            while ((!boardIsEmpty(N, array)) && (!gameIsOver))
            {
                while (humanTurn)
                {
                    emptyRow = rowIsEmpty(array, N, lastSelectedRow);
                    emptyColumn = columnIsEmpty(array, N, lastSelectedColumn);
                    if (emptyRow && emptyColumn)
                    {
                        gameIsOver = true;
                        Console.WriteLine("There are no valid selections in either the row or the column. Game is over."); 
                        // Find a remaining number 
                        //findAvailableSelection(array, N, ref lastSelectedRow, ref lastSelectedColumn); 
                        // Print grid with that number being indicated as the last selection 
                        //printGrid(N, array, lastSelectedRow, lastSelectedColumn); 
                    }
                    Console.WriteLine("Enter the row of your selection: ");
                    line = Console.ReadLine();
                    // while(is numeric AND is a valid 0-based number

                    while (!int.TryParse(line, out rowSelection) && rowSelection >= N-1)
                    {
                        // This part isn't quite right. It doesn't actually have to be in the same row, it can be same row OR same column
                        Console.WriteLine("Enter the row of your selection (must be in row " + lastSelectedRow + "): ");
                        line = Console.ReadLine(); 
                        if (rowSelection > N - 1)
                            Console.WriteLine("Invalid entry.");
                    }

                    Console.WriteLine("Enter the column of your selection: ");
                    line = Console.ReadLine();
                    while (!int.TryParse(line, out columnSelection) && rowSelection >= N - 1)
                    {
                        Console.WriteLine("Enter the column of your selection: ");
                        line = Console.ReadLine();
                        if (columnSelection > N - 1)
                            Console.WriteLine("Invalid entry.");
                    }

                    // If either the rowSelection is the same, or the column selection is the same as the last selection. (For rules of the game)
                    if (!(rowSelection == lastSelectedRow || columnSelection == lastSelectedColumn || rowSelection > N-1 || columnSelection > N-1))
                    {
                       
                        Console.WriteLine("Please select either a value in row " + lastSelectedRow + " or column " + lastSelectedColumn + " and between 0 and " + (N-1) + ".");
                        break; 
                    }
                    
                    Console.WriteLine("emptyRow is " + emptyRow + " and emptyColumn is " + emptyColumn); 
                    value = array[rowSelection, columnSelection];
                    lastSelectedRow = rowSelection;
                    lastSelectedColumn = columnSelection; 
                    if (value == 'X')
                    {
                        Console.WriteLine("That coordinate has already been selected. Please choose another different number.");
                        break;
                    }
                    else
                    {
                        array[rowSelection, columnSelection] = 'X';
                        userScore += value; 
                        Console.WriteLine("You have selected " + value + " from array[" + rowSelection + "," + columnSelection + "].");
                        //humanTurn = false;
                    }
                    humanTurn = false;
                    printScore(userScore, computerScore);
                    printGrid(N, array, lastSelectedRow, lastSelectedColumn);
                }
                while (!humanTurn)
                {
                    emptyRow = rowIsEmpty(array, N, lastSelectedRow);
                    emptyColumn = columnIsEmpty(array, N, lastSelectedColumn);
                    if (emptyRow && emptyColumn)
                    {
                        Console.WriteLine("There are no valid selections in either the row or the column. Game is over."); 
                        gameIsOver = true; 
                    }
                    getCPUSelection(N, array, ref rowSelection, ref columnSelection, lastSelectedRow, lastSelectedColumn);
                    value = array[rowSelection, columnSelection];
                    lastSelectedRow = rowSelection;
                    lastSelectedColumn = columnSelection;
                    if (value == 'X')
                    {
                        Console.WriteLine("That coordinate has already been selected.");
                        
                        break;
                    }
                    else
                    {
                        array[rowSelection, columnSelection] = 'X';
                        computerScore += value; 
                        Console.WriteLine("CPU selected " + value + " from array[" + rowSelection + "," + columnSelection + "].");


                        //humanTurn = true;
                    }

                    humanTurn = true; 
                    printScore(userScore, computerScore);
                    printGrid(N, array, lastSelectedRow, lastSelectedColumn);
                }
            }
            #endregion

            #region Print the outcome of the game 
            // The game is over, print the winner!
            if (userScore > computerScore)
                Console.WriteLine("\nCongratulations! You have successfully beat the computer by a score of " + userScore + " to " + computerScore + ".");
            else if (userScore < computerScore)
                Console.WriteLine("\nYou lost to CPU by a score of " + userScore + " to " + computerScore + ". Are you some sort of idiot!?");
            #endregion 
            
            #region Press Enter to exit...
            Console.WriteLine("Press Enter to exit....");
            KInfo= Console.ReadKey(true);
            while (KInfo.Key.ToString() != "Enter")
            {
                Console.WriteLine("Press Enter to exit...");
                KInfo = Console.ReadKey(true); 
            }

            if (KInfo.Key.ToString() == "Enter")
                return;
            #endregion 


        }
    }
}
