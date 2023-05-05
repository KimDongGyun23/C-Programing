using System;
using SudokuDataLib;
class Program
{
    static int number = 3;
    static int[,,] test_case = {
        {
            {5, 3, 4, 6, 7, 8, 9, 1, 2},
            {6, 7, 2, 1, 9, 5, 3, 4, 8},
            {1, 9, 8, 3, 4, 2, 5, 6, 7},
            {8, 5, 9, 7, 6, 1, 4, 2, 3},
            {4, 2, 6, 8, 5, 3, 7, 9, 1},
            {7, 1, 3, 9, 2, 4, 8, 5, 6},
            {9, 6, 1, 5, 3, 7, 2, 8, 4},
            {2, 8, 7, 4, 1, 9, 6, 3, 5},
            {3, 4, 5, 2, 8, 6, 1, 7, 9}
        },
        {
            {2, 8, 7, 1, 5, 4, 6, 3, 9},
            {3, 1, 6, 7, 9, 2, 4, 5, 8},
            {9, 5, 4, 6, 8, 3, 1, 7, 2},
            {5, 9, 8, 2, 4, 1, 7, 6, 3},
            {4, 3, 1, 9, 7, 6, 5, 2, 8},
            {7, 6, 2, 3, 8, 5, 9, 1, 4},
            {8, 2, 5, 4, 3, 9, 7, 6, 1},
            {1, 4, 3, 5, 2, 8, 9, 1, 7},
            {6, 7, 9, 8, 1, 7, 2, 4, 5}
        },
        {
            {8,5,9,6,1,2,4,3,7},
            {7,2,3,8,5,4,1,6,9},
            {6,1,4,7,9,3,5,2,8},
            {4,6,8,1,7,9,3,5,2},
            {3,7,5,2,4,8,9,1,6},
            {1,9,2,5,3,6,7,8,4},
            {2,3,6,4,8,1,7,9,5},
            {9,1,7,3,6,5,2,8,4},
            {5,8,1,9,2,7,6,4,3}
        },
        {
            {8,5,6,9,4,1,2,7,3},
            {4,1,9,5,6,2,7,3,8},
            {7,2,3,3,8,4,4,1,9},
            {9,6,5,7,3,4,8,2,1},
            {3,7,1,2,9,8,6,5,4},
            {2,4,8,1,5,6,9,7,7},
            {1,9,7,4,2,3,5,8,6},
            {5,8,2,6,7,9,1,4,3},
            {6,3,4,8,1,5,9,6,2}
        }
    };
    static void Main()
    {
        GameBorad gameBorad = new GameBorad();

        for (int n = 0; n < gameBorad.Size; n++)
        {
            for (int m = 0; m < gameBorad.Size; m++)
                gameBorad[n, m] = Program.test_case[number, n, m];
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write($"{test_case[number, i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        for (int i = 0; i < 9; i++)
        {
            Console.Write("Row {0}: {1}\n", i, gameBorad.IsValidGroup(GroupType.Row, i));
            if (!gameBorad.IsValidGroup(GroupType.Row, i))
            {
                Console.Write("wrong cell: ");
                foreach (Tuple<int, int> tuple in gameBorad.FindWrongCells(GroupType.Row, i))
                    Console.Write($"({tuple.Item1}, {tuple.Item2}) ");
                Console.WriteLine();
            }
        }
        Console.WriteLine();

        for (int i = 0; i < 9; i++)
        {
            Console.Write("Col {0}: {1}\n", i, gameBorad.IsValidGroup(GroupType.Colum, i));
            if (!gameBorad.IsValidGroup(GroupType.Colum, i))
            {
                Console.Write("wrong cell");
                foreach (Tuple<int, int> tuple in gameBorad.FindWrongCells(GroupType.Colum, i))
                    Console.Write($"({tuple.Item1}, {tuple.Item2}) ");
                Console.WriteLine();
            }
        }
        Console.WriteLine();

        for (int i = 0; i < 9; i++)
        {
            Console.Write("Area {0}: {1}\n", i, gameBorad.IsValidGroup(GroupType.Area, i));
            if (!gameBorad.IsValidGroup(GroupType.Area, i))
            {
                Console.Write("wrong cell");
                foreach (Tuple<int, int> tuple in gameBorad.FindWrongCells(GroupType.Area, i))
                    Console.Write($"({tuple.Item1}, {tuple.Item2}) ");
                Console.WriteLine();
            }
        }
        Console.WriteLine();


        Console.Write("Sudoku Valid: {0}\n", gameBorad.IsValidSudoku());

    }
}