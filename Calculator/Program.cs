using System;
using System.Data;
using System.Reflection.PortableExecutable;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] LongFirstNumber = new int[1];
            bool PositivityOfFirstNumber;
            double FirstNumber;
            long SecondNumber;


            Console.Write("Input value: ");
            while (!double.TryParse(Console.ReadLine(), out FirstNumber))
            {
                Console.WriteLine("Invalid operation!");
                Console.Write("Input value: ");
            }
            if (FirstNumber != Math.Abs(FirstNumber))
            {
                PositivityOfFirstNumber = false;
            }
            else
            {
                PositivityOfFirstNumber = true;
            }
            FirstNumber = Math.Abs(FirstNumber);
            SecondNumber = (long) FirstNumber;
            double FractionalPartOfNumber = FirstNumber - SecondNumber;
            int i = 0;
            long buf;
            while (SecondNumber > 0)
            {
                if (i == LongFirstNumber.Length)
                {
                    Array.Resize(ref LongFirstNumber, i + 1);
                }
                buf = SecondNumber % 1000000;
                LongFirstNumber[i] = (int) buf;
                SecondNumber /= 1000000;
                ++i;
            }
            

            while (true)
            {
                Console.WriteLine("Input operation:     +     -     *     /");
                string s = Console.ReadLine();
                while (s != "+" && s != "-" && s != "*" && s != "/")
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine("Input operation:     +     -     *     /");
                    s = Console.ReadLine();
                }
                
                Console.Write("Input value: ");
                while (!long.TryParse(Console.ReadLine(), out SecondNumber))
                {
                    Console.WriteLine("Invalid operation!");
                    Console.Write("Input value: ");
                }

                switch (s)
                {
                    case "+": 
                        Sum(ref PositivityOfFirstNumber, ref LongFirstNumber, ref FractionalPartOfNumber, ref SecondNumber); 
                        break;
                    case "-": 
                        SecondNumber *= -1; 
                        Sum(ref PositivityOfFirstNumber, ref LongFirstNumber, ref FractionalPartOfNumber, ref SecondNumber);
                        break;
                    case "*":
                        Multiplication(ref PositivityOfFirstNumber, ref LongFirstNumber, ref FractionalPartOfNumber, ref SecondNumber);
                        break;
                    case "/":
                        Division(ref PositivityOfFirstNumber, ref LongFirstNumber, ref FractionalPartOfNumber, ref SecondNumber);
                        break;
                }

                Console.Write("Result: ");
                LongWrite(ref PositivityOfFirstNumber, ref LongFirstNumber, ref FractionalPartOfNumber);
                Console.WriteLine();

                Console.WriteLine("Continue: Y/N");
                s = Console.ReadLine();
                while (s != "Y" && s != "N" && s != "y" && s != "n")
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine("Continue: Y/N");
                    s = Console.ReadLine();
                }
                if (s == "N" || s == "n")
                {
                    return;
                }
            }

        }

        static void Sum (ref bool PositivityOfFirstNumber, ref int[] LongFirstNumber, ref double FractionalPartOfNumber, ref long SecondNumber)
        {
            int i = 0;
            if (PositivityOfFirstNumber == true && Math.Abs(SecondNumber) != SecondNumber || PositivityOfFirstNumber == false && Math.Abs(SecondNumber) == SecondNumber)
            {
                bool cb;
                if (Math.Abs(SecondNumber) == SecondNumber)
                {
                    cb = true;
                }
                else
                {
                    cb = false;
                }
                long compare = LongFirstNumber[0];

                i = 1;
                while (i < LongFirstNumber.Length)
                {
                    if (i == 1)
                    {
                        compare = compare + LongFirstNumber[i];
                    }
                    else
                    {
                        compare = compare + LongFirstNumber[i] * 1000000000000;
                        break;
                    }
                    ++i;
                }
                SecondNumber = Math.Abs(SecondNumber);
                if (compare < SecondNumber)
                {
                    PositivityOfFirstNumber = cb;
                    compare = SecondNumber - compare;
                }
                else 
                {
                    compare = compare - SecondNumber;              
                }
                i = 0;
                long buf;
                while (compare > 0)
                {                    
                    buf = compare % 1000000;
                    LongFirstNumber[i] = (int)buf;
                    compare /= 1000000;
                    ++i;
                }
            }
            else
            {
                SecondNumber = Math.Abs(SecondNumber);
                long per_old = (LongFirstNumber[i] + SecondNumber) / 1000000;
                long buf = (LongFirstNumber[i] + SecondNumber) % 1000000;
                LongFirstNumber[0] = (int)buf;
                i = 1;
                long per_new;
                while (per_old != 0 || i < LongFirstNumber.Length)
                {
                    if (per_old != 0 && i == LongFirstNumber.Length)
                    {
                        Array.Resize(ref LongFirstNumber, i + 1);
                    }
                    per_new = (LongFirstNumber[i] + (per_old % 1000000)) / 1000000;
                    buf = (LongFirstNumber[i] + (per_old % 1000000)) % 1000000;
                    LongFirstNumber[i] = (int)buf;
                    per_old = (per_old / 1000000) + per_new;
                    ++i;
                }
            }
        }

        static void Multiplication (ref bool PositivityOfFirstNumber, ref int[] LongFirstNumber, ref double FractionalPartOfNumber, ref long SecondNumber)
        {
            if (PositivityOfFirstNumber == false && Math.Abs(SecondNumber) == SecondNumber || PositivityOfFirstNumber == true && Math.Abs(SecondNumber) != SecondNumber)
            {
                PositivityOfFirstNumber = false;
            }
            else
            {
                PositivityOfFirstNumber = true;
            }
            SecondNumber = Math.Abs(SecondNumber);

            int i = 0;
            long per_old;
            long per_new;
            long buf;

            FractionalPartOfNumber *= SecondNumber;
            per_old = (long)FractionalPartOfNumber;
            FractionalPartOfNumber -= per_old;

            while (per_old != 0 || i < LongFirstNumber.Length)
            {
                if (per_old != 0 && i == LongFirstNumber.Length)
                {
                    Array.Resize(ref LongFirstNumber, i+1);
                }                
                per_new = (LongFirstNumber[i] * SecondNumber + (per_old % 1000000)) / 1000000;
                buf = (LongFirstNumber[i] * SecondNumber + (per_old % 1000000)) % 1000000;
                LongFirstNumber[i] = (int) buf;
                per_old = (per_old / 1000000) + per_new;
                ++i;
            }
        }

        static void Division (ref bool PositivityOfFirstNumber, ref int[] LongFirstNumber, ref double FractionalPartOfNumber, ref long b)
        {
            if (PositivityOfFirstNumber == false && Math.Abs(b) == b || PositivityOfFirstNumber == true && Math.Abs(b) != b)
            {
                PositivityOfFirstNumber = false;
            }
            else
            {
                PositivityOfFirstNumber = true;
            }
            b = Math.Abs(b);

            int i = LongFirstNumber.Length - 1;
            long per = 0;
            long buf;
            while (i >= 0)
            {
                buf = per * 1000000 + LongFirstNumber[i];
                per = buf % b;
                LongFirstNumber[i] = (int) (buf / b);
                if (LongFirstNumber[i] == 0 && i == LongFirstNumber.Length - 1)
                {
                    Array.Resize(ref LongFirstNumber, i);
                }
                --i;
            }
            FractionalPartOfNumber = (per + FractionalPartOfNumber) / b;
        }

        static void LongWrite(ref bool PositivityOfFirstNumber, ref int[] LongFirstNumber, ref double FractionalPartOfNumber)
        {
            if (PositivityOfFirstNumber == false)
            {
                Console.Write("-");
            }
            if (LongFirstNumber.Length > 0)
            {
                Console.Write(LongFirstNumber[LongFirstNumber.Length - 1]);
                for (int i = LongFirstNumber.Length - 2; i >= 0; i--)
                {
                    int nuller = 5;
                    while (nuller > 0)
                    {
                        if (LongFirstNumber[i] / Math.Pow(10, nuller) == 0)
                        {
                            Console.Write(0);
                            --nuller;
                        }
                        else
                        {
                            nuller = 0;
                        }
                    }
                    Console.Write(LongFirstNumber[i]);
                }
            }
            else
            {
                Console.Write(0);
            }
            if (FractionalPartOfNumber > 0)
            {
                string StringF = FractionalPartOfNumber.ToString();
                for (int i = 1; i < StringF.Length; i++)
                {
                    Console.Write(StringF[i]);
                }
            }
        }
    }
}
