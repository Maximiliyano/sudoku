using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validationSudoku
{
    class Program
    {
        static int N = 9;

        static void isCheckRows(int[,] matrix)
        {
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    if(matrix[i][j] < 1 || matrix[i][j] == Math.Sqrt(i) == Math.Sqrt(j))
                    {
                        Console.WriteLine("Valid");
                    }
                }
            }
        }

        static void isCheckColumn()
        {
            for(int i = 0; i < N; i++)
            {

            }
        }

        static void isValidSudoku(int[,] matrix)
        {
            Console.WriteLine("Valid");
        }

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

            isValidSudoku(matrix);
        }
    }
}