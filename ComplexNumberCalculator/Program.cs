﻿namespace ComplexNumberCalculator
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Too few arguments");
                Console.WriteLine("Type --help for help");
                Environment.Exit(0);
            }

            if (args[0] == "--help")
            {
                Console.WriteLine("Here is your help");
                Environment.Exit(0);
            }

            if (args.Length > 1)
            {
                if (args[1] == "-p")
                {
                    if (args.Length > 2 && args.Length < 4)
                    {
                        try
                        {
                            int precision = Convert.ToInt32(args[2]);
                            ComplexNumber.Precision = precision;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid precision provided");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No value for precision provided");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid arguments provided");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine(new ComplexNumber(args[0]));
        }
    }
}