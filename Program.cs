using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validationSudoku
{
    class Program
    {   
        static bool ValidRow(int[,] matrix, int row)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if(matrix[row,i] < 1 || matrix[row,i] > 9)
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
                if(matrix[i,col] < 1 || matrix[i,col] > 9)
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
                    if(matrix[row,col] < 1 || matrix[row,col] > 9)
                    {
                        Console.WriteLine("Invalid value");
                        return false;
                    } 
                }
            }
            return true;
        }
        
        static void ValidCount(int[,] matrix, int N) 
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
                    matrix[row,col] = random.Next(1, 9);
                }
            }
        }

        static int[,] KeyBoardFillMatrix(int N)
        {
            int[,] output = new int[N,N];
            for(int i = 0; i < N; i++) 
            {
                string[] input = new string[N];
                Console.WriteLine("Enter the row the sudocu: ");
                do
                {
                    input = Console.ReadLine().Trim().Split();

                    int getAStringLength = input.GetLength(0);
                    if (getAStringLength < N || getAStringLength > N)
                        Console.WriteLine("- Please enter the row again:");
                    else
                        break;
                } 
                while (true);
                for(int j = 0; j < N; j++)
                {
                    output[i,j] = int.Parse(input[j]);
                }
            }
            return output;
        }

        static int SumOfRow(int[,] matrix, int rowNum)
        {
            int sum = 0;
            for(int i = 0; i < matrix.Length; i++)
            {
                sum += matrix[rowNum, i];
            }
            return sum;
        }

        static int SumOfColumn(int[,] matrix, int columnNum)
        {
            int sum = 0;
            for(int i = 0; i < matrix.Length; i++)
            {
                sum += matrix[i, columnNum];
            }
            return sum;
        }

        static int PivotSum(int N)
        {
            int sum = 0;
            for (int i = 1; i <= N; i++)
                sum += i;
            return sum;
        }

        static bool IsCorrectSudocu(int[,] matrix)
        {
            int pivotSum = PivotSum(matrix.Length);

            for(int i = 1; i < matrix.Length; i++)
            {
                int sumOfRow = SumOfRow(matrix, i);
                if (sumOfRow != pivotSum)
                    return false;
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                int sumOfСolumn = SumOfColumn(matrix, i);
                if (sumOfСolumn != pivotSum)
                    return false;
            }

            return true;
        }

        static void Display(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write("\t" + matrix[i,j]);

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter size sudoku: ");
            int input_size = Convert.ToInt16(Console.ReadLine());

            if(input_size < 1) Console.Write("You entered wrong count!"); 

            int[,] matrix = new int[input_size,input_size];

            Console.Write("Fill massive, enter 'true' (random) or 'false' (manual): ");
            bool input_statement = Convert.ToBoolean(Console.ReadLine());

            if (!input_statement) matrix = KeyBoardFillMatrix(input_size);
            else RandomFillMassive(matrix);

            // Валідація цифр
            ValidCount(matrix, input_size);

            // Валідація судоку
            //IsCorrectSudocu(matrix);
            
            // Вивід масиву
            Display(matrix);

            Console.ReadKey();
        }
    }
}