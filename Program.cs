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
        
        static bool ValidRow(int[,] matrix, int row)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if(matrix[row, i] < 0 || matrix[row, i] > N)
                {
                    Console.WriteLine("Invalid value");
                    return false;
                }
            }
            return true;
        }
        
        static bool ValidColumn(int[,] matrix, int col)
        {
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                if(matrix[i, col] < 0 || matrix[i, col] > N)
                {
                    Console.WriteLine("Invalid value");
                    return false;
                }
            }
            return true;
        }
        
        static bool ValidSubSquares(int[,] matrix)
        {
            for(int row = 0; row < matrix.GetLength(0); row = row + 3)
            {
                for(int col = 0; col < matrix.GetLength(1); col = col + 3)
                {
                    if(matrix[row, col] < 0 || matrix[row, col] > N)
                    {
                        Console.WriteLine("Invalid value");
                        return false;
                    } 
                }
            }
            return true;
        }
        
        static void ValidCount(int[,] matrix) 
        {
            for(int i = 0; i < N; i++)
            {   
                if(!ValidRow(matrix, i) || !ValidColumn(matrix, i))
                {
                    Console.WriteLine("Count is invalid");
                    return;
                }
            }

            if(!ValidSubSquares(matrix)) Console.WriteLine("Count is invalid");
        }

        static void RandomFillMassive(int[,] matrix)
        {
            Random random = new Random();

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = random.Next(1, N);
                }
            }
        }

        static void ManualFillMassive(int[,] matrix)
        {
            Console.Write("Enter {0} row values: ", N);
            
            string[] str = Console.ReadLine().Split();
            foreach(string cut in str)
            {
                if(cut.Trim() != "")
                {
                    int[] count = new int[N];

                    for(int i = 0; i < matrix.GetLength(0); i++) 
                    {
                        count[i] = Int32.Parse(cut);
                        if(count[i] < 1 || count[i] > N) 
                        {
                            Console.WriteLine("Enter row again!");
                            break;
                        }
                        matrix[0, i] = count[i];
                    }
                    //Console.WriteLine(count);
                }
            }
            /*if(str.Length() > N) Console.Write("Enter row again: ");
            for(int i = 0; i < str.Length; i++)
            {
                int[] rows = new int[N]; 
                rows[i] = Convert.ToInt32(str);
                Console.WriteLine("{0}", rows);
            }*/
        }

        static void ValidSudoku(int[,] matrix) 
        {
            int summa = 0, summas = 0;
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                summa += matrix[row, 0];
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    summas += matrix[0, col];
                }
            }
            if(summa != summas) Console.WriteLine("Sudoku is not valid!");
            else Console.WriteLine("Sudoku is valid!");
        }

        static void DisplaySudoku(int[,] matrix)
        {
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,] matrix = new int[N,N];

            Console.Write("Fill massive, enter 'true' (random) or 'false' (manual): ");
            bool input_params = Convert.ToBoolean(Console.ReadLine());

            if (!input_params) ManualFillMassive(matrix);
            else RandomFillMassive(matrix);

            // Валідація цифр
            ValidCount(matrix);

            // Валідація судоку
            ValidSudoku(matrix);
            
            // Вивід масиву
            DisplaySudoku(matrix);
        }
    }
}