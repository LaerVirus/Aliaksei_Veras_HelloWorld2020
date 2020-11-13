using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TypeMetod
{
    class Program
    {
        public readonly Type Int = typeof(int);

        static object argGetType(string arg)
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

            switch (Bufer.GetType().Name)
            {
                case "String": return $"{arg} is string";
                case "Byte": return $"{arg} is byte";
                case "SByte": return $"{arg} is sbyte";
                case "Int16": return $"{arg} is short";
                case "UInt16": return $"{arg} is ushort";
                case "Int32": return $"{arg} is int";
                case "UInt32": return $"{arg} is uint";
                case "Int64": return $"{arg} is long";
                case "UInt64": return $"{arg} is ulong";
                case "Char": return $"{arg} is char";
                case "Boolen": return $"{arg} is bool";
                case "Double": return $"{arg} is double";
                case "Single": return $"{arg} is float";
            }
            return $"{arg} is хз";
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите arg.");
            Console.WriteLine(argGetType(Console.ReadLine())); 
        }
    }
}
