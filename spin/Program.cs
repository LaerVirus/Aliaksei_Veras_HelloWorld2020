using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace spin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("РАЗМЕР КВАДРАТНОЙ МАТРИЦЫ:");
            Console.WriteLine();
            int m;
            do
            {
                Console.Write("Введите количество столбцов(натуральное число): ");

            }
            while (!int.TryParse(Console.ReadLine(), out m) || m <= 0);
            int n;   
            do
            {
                Console.Write("Введите количество строк(натуральное число): ");

            }
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);            

            int[,] a = new int[n, m];
            int end = m*n;

            int i = 0;
            int j = 0;

            int MaxM = m - 1;
            int MinM = 0;
            int MaxN = n - 1;
            int MinN = 1;

            for (int Num = 1; Num <= end; Num++)
            {
                a[i, j] = Num;
                if (j < MaxM && i == MinN - 1)
                {
                    ++j;
                    if (j == MaxM)
                    {
                        --MaxM;
                    }
                }
                else if (i < MaxN && j == MaxM + 1)
                {
                    ++i;
                    if (i == MaxN)
                    {
                        --MaxN;
                    }
                }
                else if (j > MinM && i == MaxN + 1)
                {
                    --j;
                    if (j == MinM)
                    {
                        ++MinM;
                    }
                }
                else if (i > MinN && j == MinM - 1)
                {
                    --i;
                    if (i == MinN)
                    {
                        ++MinN;
                    }
                }

            }
            
            Console.WriteLine();
            Console.WriteLine("Готовая матрица-спиралька:");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    } 
}
