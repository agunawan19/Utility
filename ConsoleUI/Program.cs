using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            // Console.WriteLine("Hello World!");
            //StringBuilderDemo();
            //StringConcatDemo();
            //StringOperationDemo();
            StringBuilderDemo();
            //StringConcatDemo();
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        private static void StringOperationDemo()
        {
            string s = string.Empty;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1_000; i++) {
                //s = "Test" + i + " " + i;
                s = $"Test{i} {i} ";
            }

            Console.WriteLine(s.Length);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        }

        private static void StringConcatDemo()
        {
            string s = string.Empty;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 10_000; i++) {
                s += "Test" + i + " ";
            }

            Console.WriteLine(s.Length);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        }

        private static void StringBuilderDemo()
        {
            var stringBuilder = new StringBuilder();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 10_000; i++) {
                stringBuilder.Append("Test").Append(i).Append(" ");
            }

            string s = stringBuilder.ToString();
            Console.WriteLine(s.Length);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        }
    }
}
