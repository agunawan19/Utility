using System;
using FizzBuzz.Library;

namespace ConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumber(1, 100);
        }

        private static void PrintNumber(int start, int end)
        {
            for (int i = start; i <= end; i++) {
                Console.WriteLine($"{i} - {FizzBuzzer.GetValue(i)}");
            }

            Console.ReadLine();
        }
    }
}
