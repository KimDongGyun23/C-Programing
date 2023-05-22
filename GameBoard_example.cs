using System;
using SudokuDataLib;
class Program
{
    static int number = 0;

    static void Main()
    {
        GameBoard gameBoard;
        bool[,] odd_grid=null;
        //랜덤 생성 테스트
        if(number == 3)
        {
            gameBoard = new OddEvenSudokuGameBoard(81, 3);
            gameBoard.ResetSudoku();
        }
        else if(number == 2)
        {
            gameBoard = new SamuraiSudokuGameBoard(9*41);
            gameBoard.ResetSudoku();
        }
        else if (number == 1)
        {
            gameBoard = new RegularSudokuGameBoard(256,4);

            gameBoard.ResetSudoku();

        }
        else
        {
            gameBoard = new RegularSudokuGameBoard(10,3);
            gameBoard.ResetSudoku();
        }
            

        //속성 호출 예시
        for (int i = 0; i < gameBoard.GridSize; i++)
        {
            for (int j = 0; j < gameBoard.GridSize; j++)
            {
                Console.Write($"{gameBoard[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        //고정 셀 확인 예시
        for (int i = 0; i < gameBoard.GridSize; i++)
        {
            for (int j = 0; j < gameBoard.GridSize; j++)
            {
                Console.Write($"{gameBoard.IsFixed[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        if(number == 3)
        {
            //홀짝 스도쿠의 홀수 칸 출력
            for (int i = 0; i < gameBoard.GridSize; i++)
            {
                for (int j = 0; j < gameBoard.GridSize; j++)
                {
                    Console.Write($"{gameBoard.GetColoredGrid()[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        //스도쿠 유효성 검사 예시
        Console.Write("Sudoku Valid: {0}\n", gameBoard.IsValidSudoku());

    }
}