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

        static bool isCheckTable(int[,] matrix)
        {
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    if(matrix[i, j] > 1 && Math.Sqrt(N) == i)
                       return true;
                }
            }
            return false;
        }

        static bool isValidSudoku(int[,] matrix)
        {
            if(isCheckTable(matrix) == false) 
                return false;

            bool[] unique = new bool[N + 1];
            for(int i = 0; i < N; i++)
            {
                Array.Fill(unique, false);

                for(int j = 0; j < N; j++)
                {
                    int Z = matrix[i, j];
                    if (unique[Z])
                    {
                        return false;
                    }
                    unique[Z] = true;
                }
            }
    
            for(int i = 0; i < N; i++)
            {
                Array.Fill(unique, false);
    
                for(int j = 0; j < N; j++)
                {
                    int Z = matrix[j, i];
                    if (unique[Z])
                    {
                        return false;
                    }
                    unique[Z] = true;
                }
            }
    
            for(int i = 0; i < N - 2; i += 3)
            {
                
                for(int j = 0; j < N - 2; j += 3)
                {
                    Array.Fill(unique, false);
        
                    for(int k = 0; k < 3; k++)
                    {
                        for(int l = 0; l < 3; l++)
                        {
                            int X = i + k;
                            int Y = j + l;
                            int Z = matrix[X, Y];
        
                            if (unique[Z])
                            {
                                return false;
                            }
                            unique[Z] = true;
                        }
                    }
                }
            }
            return true;
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
            
            if(isValidSudoku(matrix)) Console.WriteLine("Valid");
            else Console.WriteLine("Not Valid");
            

            Console.WriteLine("[");
            for(int row = 0; row < Math.Sqrt(N); row++)
            {
                for(int col = 0; col < Math.Sqrt(N); col++)
                {
                    Console.Write(matrix[row, col] + ",");
                }
            }
            Console.WriteLine("\n]");
        }
    }
}