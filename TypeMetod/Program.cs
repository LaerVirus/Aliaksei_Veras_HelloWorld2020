using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TypeMetod
{
    class Program
    {
        public readonly Type Int = typeof(int);

        static object argGetType(object arg)
        {
            string StringArg = (string) arg;
            object Bufer;

            try
            {
                Bufer = Convert.ToDouble(StringArg);
                try
                {
                    Bufer = Convert.ToSByte(StringArg);
                }
                catch
                {
                    try
                    {
                        Bufer = Convert.ToUInt16(StringArg);
                    }
                    catch
                    {
                        try
                        {
                            Bufer = Convert.ToInt16(StringArg);
                        }
                        catch
                        {
                            try
                            {
                                Bufer = Convert.ToUInt32(StringArg);
                            }
                            catch
                            {
                                try
                                {
                                    Bufer = Convert.ToInt32(StringArg);
                                }
                                catch
                                {
                                    try
                                    {
                                        Bufer = Convert.ToUInt64(StringArg);
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            Bufer = Convert.ToInt64(StringArg);
                                        }
                                        catch
                                        {
                                            try
                                            {
                                                Bufer = Convert.ToSingle(StringArg);
                                            }
                                            catch
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                try
                {
                    Bufer = Convert.ToBoolean(StringArg);
                }
                catch
                {
                    try
                    {
                        Bufer = Convert.ToChar(StringArg);
                    }
                    catch
                    {
                        Bufer = StringArg;
                    }
                }
            }

            return $"{arg} is " + Bufer.GetType();
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите arg.");
            Console.WriteLine(argGetType(Console.ReadLine())); 
        }
    }
}
