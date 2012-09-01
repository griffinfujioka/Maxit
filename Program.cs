using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 



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

        #region printGrid(int size, int[,] array)
        public static void printGrid(int size, int[,] array)
        {
            int N = size;
            int i,j;
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

            #region Print rows of numbers
            for (i = 0; i < N; i++)
            {
                Console.Write(i + "| ");   // Write the row number 

                for (j = 0; j < N; j++)
                {

                    Console.Write(array[i, j] + "\t");
                    
                }

                Console.Write("\n"); 
                

            }
            #endregion 
        }
        #endregion 

        static void Main(string[] args)
        {
            System.Console.Write("Welcome to Maxit!\n\n");
            int N = 0;

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

            Console.WriteLine("Thank you for writing a numeric value. N is " + N + "."); 
            #endregion 

            int[,] array = new int[N, N];       // Now we can create an array for the game. 

            #region Determine the 0-indexes of the grid. (N-1)
            int bound0 = array.GetUpperBound(0);    // bound0 = N-1
            int bound1 = array.GetUpperBound(1);    //  = bound1 = N-1
            Console.WriteLine("The 0-based size of the grid is " + bound0 + "."); 
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

            printGrid(N, array); 

            // Prompt for user selection
                // While there are selections remaining()
            while (!boardIsEmpty(N, array))
            Console.WriteLine("Press Enter to exit....");
            System.ConsoleKeyInfo KInfo= Console.ReadKey(true);
            while (KInfo.Key.ToString() != "Enter")
            {
                Console.WriteLine("Press Enter to exit...");
                KInfo = Console.ReadKey(true); 
            }

            if (KInfo.Key.ToString() == "Enter")
                return;
            

        }
    }
}
