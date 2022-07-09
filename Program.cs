using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validationSudoku
{
    class Program
    {
        static readonly int N = 9;
        
        static int ValidRow(int row, int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if(matrix[row, i] < 0 || matrix[row, i] > N)
                {
                    Console.WriteLine("Invalid value");
                    return 0;
                }
            }
            return 1;
        }
        
        static int ValidColumn(int col, int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                if(matrix[i, col] < 0 || matrix[i, col] > N)
                {
                    Console.WriteLine("Invalid value");
                    return 0;
                }
            }
            return 1;
        }
        
        static int ValidSubSquares(int[,] matrix)
        {
            for(int row = 0; row < matrix.GetLength(0); row = row + 3)
            {
                for(int col = 0; col < matrix.GetLength(1); col = col + 3)
                {
                    //for(int r = row; r < row + 3; r++)
                    //for(int c = col; c < col + 3; c++)
                    if(matrix[row, col] < 0 || matrix[row, col] > N)
                    {
                        Console.WriteLine("Invalid value");
                        return 0;
                    } 
                }
            }
            return 1;
        }
        
        static void ValidSudoku(int[,] matrix) 
        {
            for(int i = 0; i < N; i++)
            {
                int row = ValidRow(i, matrix);
                int column = ValidColumn(i, matrix);
                
                if(row < 1 || column < 1)
                {
                    Console.WriteLine("Sudoku is invalid");
                    return;
                }
            }
            int valid = ValidSubSquares(matrix);

            if(valid < 1) Console.WriteLine("Sudoku is invalid");
            else Console.WriteLine("Sudoku is valid");
        }

        // if(matrix[i, j] > 1 && Math.Sqrt(N) == i)

        static void Main(string[] args)
        {
            int[,] matrix = {
                {7,8,4,  1,5,9,  3,2,6},
                {5,3,9,  6,7,2,  8,4,1},
                {6,1,2,  4,3,8,  7,5,9},

                {9,2,8,  7,1,5,  4,6,3},
                {3,5,7,  8,4,6,  1,9,2},
                {4,6,1,  9,2,3,  5,8,7},

                {8,7,6,  3,9,4,  2,1,5},
                {2,4,3,  5,6,1,  9,7,8},
                {1,9,5,  2,8,7,  6,3,4}
            };

            // Вивід масиву
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine("[");
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + ", ");
                }
                Console.WriteLine("]");
            }

            // Валідація
            ValidSudoku(matrix);
        }
    }
}