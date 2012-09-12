using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Maxit; 

namespace Maxit
{
    class TestDrivers
    {
        public static string[] args = new string[] {"a", "b"};  // Dumby parameter 

        #region 1: Test options for rowIsEmpty()
        public static void test_options_1()
        {
            int choice = -1;
            string choiceEntry;
            bool isNumeric = false;
            while ((choice < 1 || choice > 7) || !isNumeric)
            {
                Console.WriteLine("----- Test Options for rowIsEmpty() ------");
                Console.WriteLine("1. Execute test cases 1.1 (1x1 empty grid, size=1)");
                Console.WriteLine("2. Execute test cases 1.2 (1x1 non-empty grid, size = 1)");
                Console.WriteLine("3. Execute test cases 1.3 (4x4 empty row 0, size = 4, search in row 0)");
                Console.WriteLine("4. Execute test cases 1.4 (4x4 empty row 0 & partially empty row 1, size = 4, search in row 1)"); 
                Console.WriteLine("5. Execute all tests."); 
                Console.WriteLine("6. Main menu"); 
                Console.WriteLine("\nEnter a selection: "); 
                choiceEntry = Console.ReadLine();
                
                isNumeric = int.TryParse(choiceEntry, out choice);        // choice now = numeric value, isNumeric = false -> Not a numeric value 
            }

            switch (choice)
            {
                
                case 1: 
                    test_1_1();
                    main(args);
                    break;
                case 2: 
                    test_1_2();
                    main(args);
                    break;
                case 3: 
                    test_1_3();
                    main(args);
                    break;
                case 4:
                    test_1_4();
                    main(args);
                    break; 
                case 5: 
                    test_1_1();
                    test_1_2();
                    test_1_3();
                    test_1_4();
                    main(args);
                    break; 
                case 6: 
                    main(args);
                    break; 
            }
            return; 
        }
        #endregion 

        #region test 1.1
        public static void test_1_1()
        {
            int[,] array = new int[1, 1] { {'X'} };
            int size = 1;   // zero based
            int row = 0;
            bool rowIsEmpty = Maxit.Program.rowIsEmpty(array, size, row);
            Console.WriteLine("Executing test 1.1...");
            Console.WriteLine("\tExpected Value is True");
            Console.WriteLine("\tActual value is " + rowIsEmpty + "\n");
        }
        #endregion 

        #region test 1.2
        public static void test_1_2()
        {
            int[,] array = new int[1, 1] { { 1 } };
            int size = 1;   // zero based
            int row = 0;
            bool rowIsEmpty = Maxit.Program.rowIsEmpty(array, size, row);
            Console.WriteLine("Executing test 1.2...");
            Console.WriteLine("\tExpected Value is False");
            Console.WriteLine("\tActual value is " + rowIsEmpty + "\n");
        }
        #endregion 

        #region test 1.3
        public static void test_1_3()
        {
            int[,] array = new int[4, 4] { { 'X', 'X', 'X', 'X' }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int size = 3;   // zero based
            int row = 0;    // zero based row. Row 1 = array[0,y] 
            bool rowIsEmpty = Maxit.Program.rowIsEmpty(array, size, row);
            Console.WriteLine("Executing test 1.3...");
            Console.WriteLine("\tExpected Value is True");
            Console.WriteLine("\tActual value is " + rowIsEmpty + "\n");
        }
        #endregion 

        #region test 1.4
        public static void test_1_4()
        {
            // Row 0 is empty, look for empty row 1
            int[,] array = new int[4, 4] { { 'X', 'X', 'X', 'X' }, { 5, 'X', 7, 'X' }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int size = 4;   // zero based
            int row = 1;    // zero based row. Row 1 = array[0,y] 
            bool rowIsEmpty = Maxit.Program.rowIsEmpty(array, size, row);
            Console.WriteLine("\nExecuting test 1.4...");
            Console.WriteLine("\tExpected Value is False");
            Console.WriteLine("\tActual value is " + rowIsEmpty + "\n");
        }
        #endregion 

        #region 2: Test options for columnIsEmpty()
        public static void test_options_2()
        {
            int choice = -1;
            string choiceEntry;
            bool isNumeric = false;
            while ((choice < 1 || choice > 7) || !isNumeric)
            {
                Console.WriteLine("----- Test Options for columnIsEmpty() ------");
                Console.WriteLine("1. Execute test cases 2.1 (1x1 empty grid, size=1, row=0)");
                Console.WriteLine("2. Execute test cases 2.2 (1x1 non-empty grid, size=1, row=0");
                Console.WriteLine("3. Execute test cases 2.3 (4x4 empty column 0, size=4, search in column 0)");
                Console.WriteLine("4. Execute test cases 2.4 (4x4 empty column 0 & partially empty column 1, size=4, search in column 1)");
                Console.WriteLine("5. Execute all tests.");
                Console.WriteLine("6. Main menu");
                Console.WriteLine("\nEnter a selection: ");
                choiceEntry = Console.ReadLine();
                isNumeric = int.TryParse(choiceEntry, out choice);        // choice now = numeric value, isNumeric = false -> Not a numeric value 
              
                

            }

            switch (choice)
            {

                case 1:
                    test_2_1();
                    main(args);
                    break;
                case 2:
                    test_2_2();
                    main(args);
                    break;
                case 3:
                    test_2_3();
                    main(args);
                    break;
                case 4:
                    test_2_4();
                    main(args);
                    break;
                case 5:
                    test_2_1();
                    test_2_2();
                    test_2_3();
                    test_2_4();
                    main(args);
                    break;
                case 6:
                    main(args);
                    break;
            }
            return;
        }
        #endregion 

        #region test 2.1
        public static void test_2_1()
        {
            int[,] array = new int[1, 1] { { 'X' } };
            int size = 1;   // zero based
            int column = 0;
            bool columnIsEmpty = Maxit.Program.columnIsEmpty(array, size, column);
            Console.WriteLine("\nExecuting test 2.1...");
            Console.WriteLine("\tExpected Value is True");
            Console.WriteLine("\tActual value is " + columnIsEmpty + "\n");
        }
        #endregion 

        #region test 2.2
        public static void test_2_2()
        {
            int[,] array = new int[1, 1] { { 1 } };
            int size = 1;   // zero based
            int column = 0;
            bool columnIsEmpty = Maxit.Program.columnIsEmpty(array, size, column);
            Console.WriteLine("Executing test 2.2...");
            Console.WriteLine("\tExpected Value is False");
            Console.WriteLine("\tActual value is " + columnIsEmpty + "\n");
        }
        #endregion 

        #region test 2.3
        public static void test_2_3()
        {
            int[,] array = new int[4, 4] { { 'X',2,3,4 }, { 'X', 6, 7, 8 }, { 'X', 10, 11, 12 }, { 'X', 14, 15, 16 } };
            int size = 4;   // zero based
            int column = 0;
            bool columnIsEmpty = Maxit.Program.columnIsEmpty(array, size, column);
            Console.WriteLine("Executing test 2.3...");
            Console.WriteLine("\tExpected Value is True");
            Console.WriteLine("\tActual value is " + columnIsEmpty + "\n");
        }
        #endregion 

        #region test 2.4
        public static void test_2_4()
        {
            int[,] array = new int[4, 4] { { 'X', 2, 3, 4 }, { 'X', 6, 'X', 8 }, { 'X', 10, 11, 12 }, { 'X', 14, 15, 16 } };
            int size = 4;   // zero based
            int column = 1;
            bool columnIsEmpty = Maxit.Program.columnIsEmpty(array, size, column);
            Console.WriteLine("Executing test 2.4...");
            Console.WriteLine("\tExpected Value is False");
            Console.WriteLine("\tActual value is " + columnIsEmpty + "\n");
        }
        #endregion 

        #region 3: Test options for getCPUSelection()
        public static void test_options_3()
        {
            int choice = -1;
            string choiceEntry;
            bool isNumeric = false;
            while ((choice < 1 || choice > 7) || !isNumeric)
            {
                Console.WriteLine("----- Test Options for getCPUSelection() ------");
                Console.WriteLine("1. Execute test case 3.1 (search for maximum value in 2x2)");
                Console.WriteLine("2. Execute test case 3.2 (search for maximum value of all negatives in a 2x2)");
                // TODO: Come up with more tests... 
                Console.WriteLine("5. Execute all tests.");
                Console.WriteLine("6. Main menu");
                Console.WriteLine("\nEnter a selection: ");
                choiceEntry = Console.ReadLine();
                isNumeric = int.TryParse(choiceEntry, out choice);        // choice now = numeric value, isNumeric = false -> Not a numeric value 
            }

            switch (choice)
            {
                case 1:
                    test_3_1();
                    main(args); 
                    break; 
                case 2:
                    test_3_2();
                    main(args);
                    break; 
                case 5: // all of the tests
                    test_3_1(); 
                    test_3_2();
                    main(args); 
                    break; 
                default: break; 
            }
        }
        #endregion 

        #region test 3.1
        public static void test_3_1()
        {
            int[,] array = new int[2, 2] { { 3, 8 }, { 11, 24 } };
            int lastSelectedRow = 0, lastSelectedColumn = 1;
            int returnedRow=0, returnedColumn=0;
            int size = 2;
            Console.WriteLine("\nExecuting test 3.1..."); 
            Maxit.Program.getCPUSelection(size, array, ref returnedRow, ref returnedColumn, lastSelectedRow, lastSelectedColumn);
            Console.WriteLine("\tExpected Value is [1,1]");
            Console.WriteLine("\tActual value is [" + returnedRow + "," + returnedColumn + "]\n");
            
        }
        #endregion

        #region test 3.2 - the lesser of two evils 
        public static void test_3_2()
        {
            int[,] array = new int[2, 2] { { -3, -8 }, { -11, -24 } };  // Would ya look at that? All of the previous array's values are negated!
            int lastSelectedRow = 0, lastSelectedColumn = 1;
            int returnedRow = 0, returnedColumn = 0;
            int size = 2;
            Console.WriteLine("\nExecuting test 3.2...");
            Maxit.Program.getCPUSelection(size, array, ref returnedRow, ref returnedColumn, lastSelectedRow, lastSelectedColumn);
            // In this case, the computer should pick -3 if it's options are -3 and -24
            // Those coordinates are [0,0]
            Console.WriteLine("\tExpected Value is [0,0]");
            Console.WriteLine("\tActual value is [" + returnedRow + "," + returnedColumn + "]\n");
            
        }
        #endregion 

        #region 4: Test options for boardIsEmpty()
        public static void test_options_4()
        {
            int choice = -1;
            string choiceEntry;
            bool isNumeric = false;
            while ((choice < 1 || choice > 9 || !isNumeric))
            {
                Console.WriteLine("----- Test Options for boardIsEmpty() ------");
                Console.WriteLine("1. Execute test case 4.1 - 1x1 empty board");
                Console.WriteLine("2. Execute test case 4.2 - 1x1 non-empty board");
                Console.WriteLine("3. Execute test case 4.3 - 3x3 with 1 available");
                Console.WriteLine("4. Execute test case 4.4 - 3x3 with 2 available");
                Console.WriteLine("5. Execute test case 4.5 - 3x3 with all available");
                Console.WriteLine("6. Execute test case 4.6 - 3x3 empty board"); 
                Console.WriteLine("7. Execute all tests.");
                Console.WriteLine("8. Main menu");
                Console.WriteLine("\nEnter a selection: ");
                choiceEntry = Console.ReadLine();
                isNumeric = int.TryParse(choiceEntry, out choice);        // choice now = numeric value, isNumeric = false -> Not a numeric value 
            }

            switch (choice)
            {
                case 1:
                    test_4_1(); 
                    main(args);
                    break;
                case 2:
                    test_4_2(); 
                    main(args);
                    break;
                case 3: 
                    test_4_3(); 
                    main(args);
                    break;
                case 4: 
                    test_4_4(); 
                    main(args);
                    break;
                case 5: 
                    test_4_5(); 
                    main(args);
                    break;
                case 6:
                    test_4_6(); 
                    main(args);
                    break;
                case 7: // all of the tests
                    test_4_1();
                    test_4_2();
                    test_4_3();
                    test_4_4();
                    test_4_5();
                    test_4_6();
                    main(args);
                    break;
                case 8:
                    main(args);
                    break; 
                default: break;
            }
        }
        #endregion 

        #region test 4.1
        public static void test_4_1()
        {
            int[,] array = new int[1, 1] { { 'X' } };
            int size = 1;   // zero based
            bool boardIsEmpty = Maxit.Program.boardIsEmpty(size, array);
            Console.WriteLine("\nExecuting test 4.1...");
            Console.WriteLine("\tExpected value is True");
            Console.WriteLine("\tActual value is " + boardIsEmpty); 
        }
        #endregion 

        #region test 4.2
        public static void test_4_2()
        {
            int[,] array = new int[1, 1] { { 1 } };
            int size = 1;   // zero based
            bool boardIsEmpty = Maxit.Program.boardIsEmpty(size, array);
            Console.WriteLine("\nExecuting test 4.2...");
            Console.WriteLine("\tExpected value is False");
            Console.WriteLine("\tActual value is " + boardIsEmpty); 
        }
        #endregion 

        #region test 4.3
        public static void test_4_3()
        {
            int[,] array = new int[3, 3] { { 'X', 'X', 'X' }, { 'X', 'X', 'X' }, { 'X', 'X', 9 } };
            int size = 3;
            bool boardIsEmpty = Maxit.Program.boardIsEmpty(size, array);
            Console.WriteLine("\nExecuting test 4.3...");
            Console.WriteLine("\tExpected value is False");
            Console.WriteLine("\tActual value is " + boardIsEmpty);
            
        }
        #endregion 

        #region test 4.4
        public static void test_4_4()
        {
            int[,] array = new int[3, 3] { { 1, 'X', 'X' }, { 'X', 'X', 'X' }, { 'X', 'X', 9 } };
            int size = 3;
            bool boardIsEmpty = Maxit.Program.boardIsEmpty(size, array);
            Console.WriteLine("\nExecuting test 4.4...");
            Console.WriteLine("\tExpected value is False");
            Console.WriteLine("\tActual value is " + boardIsEmpty);
        }
        #endregion 

        #region test 4.5
        public static void test_4_5()
        {
            int[,] array = new int[3, 3] { {1,2,3},{4,5,6},{7,8,9}};
            int size = 3;
            bool boardIsEmpty = Maxit.Program.boardIsEmpty(size, array);
            Console.WriteLine("\nExecuting test 4.5...");
            Console.WriteLine("\tExpected value is False");
            Console.WriteLine("\tActual value is " + boardIsEmpty);
        }
        #endregion 

        #region test 4.6
        public static void test_4_6()
        {
            int[,] array = new int[3, 3] { { 'X', 'X', 'X' }, { 'X', 'X', 'X' }, { 'X', 'X', 'X' } };
            int size = 3;
            bool boardIsEmpty = Maxit.Program.boardIsEmpty(size, array);
            Console.WriteLine("\nExecuting test 4.6...");
            Console.WriteLine("\tExpected value is True");
            Console.WriteLine("\tActual value is " + boardIsEmpty);
        }
        #endregion

        public static void main(string[] args)
        {
            /* ****************************************************
            Test rowIsEmpty(int[,] array, int size, int row): 
             * Send 2 dimensional array of various combinations 
             * Send array knowing which rows are/aren't empty see if you can ID them
             ******************************************************/
            int choice = -1;
            string choiceEntry;
            bool isNumeric = false;

            while ((choice < 1 || choice > 101) || !isNumeric)
            {
                Console.WriteLine("\n----- Test Options ------");
                Console.WriteLine("1. Execute test cases for rowIsEmpty()");
                Console.WriteLine("2. Execute test cases for columnIsEmpty()");
                Console.WriteLine("3. Execute test cases for getCPUSelection()");
                Console.WriteLine("4. Execute test cases for boardIsEmpty()");
                Console.WriteLine("5. Execute all tests."); 
                Console.WriteLine("12. Play game"); 
                Console.WriteLine("\nEnter a selection: "); 
                choiceEntry = Console.ReadLine();
                isNumeric = int.TryParse(choiceEntry, out choice);        // choice now = numeric value, isNumeric = false -> Not a numeric value 
           

                

            }

            switch (choice)
            {
                
                case 1: 
                    test_options_1();
                    break;
                case 2:
                    test_options_2();
                    break; 
                case 3:
                    test_options_3();
                    break; 
                case 4:
                    test_options_4();
                    break; 
                case 5: 
                    test_1_1();
                    test_1_2();
                    test_1_3();
                    test_1_4();
                    test_2_1();
                    test_2_2();
                    test_2_3();
                    test_2_4();
                    test_3_1();
                    test_3_2();
                    test_4_1();
                    test_4_2();
                    test_4_3();
                    test_4_4();
                    test_4_5();
                    test_4_6();
                    main(args);
                    break;
                case 12:
                    break; 
                default: break;
            }
        }
    }
}