using System;
using System.Linq;

namespace fact
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Давай, введи натуральное число для своего факториала");
            long n;
            while (!long.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("НАТУРАЛЬНОЕ ЧИСЛО");
            }

            long[] a = new long[1] { 1 };
            long per_new = 0;
            long per_old = 0;

            for (int i = 2; i<=n; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {

                    per_new = a[j] * i / 1000000;
                    a[j] = a[j] * i % 1000000;
                    a[j] += (per_old % 1000000);
                    per_old /= 1000000;
                    per_new += a[j] / 1000000;
                    a[j] %= 1000000;
                    long k = per_new;
                    per_new = per_old;
                    per_old = k;
                    if (j == a.Length-1 && per_old > 0)
                    {
                        
                        Array.Resize(ref a, a.Length+1);
                        a[a.Length-1] = (per_old % 1000000);
                        per_old /= 1000000;
                    }
                }
                Console.WriteLine("Состояние расчётов: " + i);
            }

            Console.WriteLine();
            Console.Write(a[a.Length-1]);
            for (int i = a.Length-2; i>=0; i--)
            {
                int nuller = 5;
                while (nuller > 0)
                {
                    if (a[i] / Math.Pow(10, nuller) == 0)
                    {
                        Console.Write(0);
                        --nuller;
                    }
                    else
                    {
                        nuller = 0;                        
                    }                    
                }
                Console.Write(a[i]);
            }
            Console.WriteLine();
        }
    }
}
