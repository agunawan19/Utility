using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        private enum Number
        {
            Zero,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
        }

        static void Main(string[] args)
        {
            //decimal myNumber = 1.01m;

            //Console.WriteLine(GetNumberText(myNumber));
            //const int numberOfLoops = 100000;

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //GetNumberText1Benchmark(numberOfLoops);
            //stopwatch.Stop();

            //Console.WriteLine(stopwatch.ElapsedMilliseconds);

            MeasureTime(GetNumberText1Benchmark, 100_000);
        }

        private static void MeasureTime(Action<int> action, int numberOfLoops)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action(numberOfLoops);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        private static void GetNumberText1Benchmark(int numberOfLoops)
        {
            decimal number = 3;

            for (var i = 0; i < numberOfLoops; i++) {
                GetNumberText(number);
            }
        }

        private static void GetNumberText2Benchmark(int numberOfLoops)
        {
            decimal number = 3;

            for (var i = 0; i < numberOfLoops; i++) {
                GetNumberText2(number);
            }
        }

        private static void GetNumberText3Benchmark(int numberOfLoops)
        {
            decimal number = 3;

            for (var i = 0; i < numberOfLoops; i++) {
                GetNumberText3((int)number);
            }
        }

        private static string GetNumberText(decimal number)
        {
            string text = string.Empty;

            switch (number) {
                case 0:
                    text = Number.Zero.ToString();
                    break;
                case 1:
                    text = Number.One.ToString();
                    break;
                case 2:
                    text = Number.Two.ToString();
                    break;
                case 3:
                    text = Number.Three.ToString();
                    break;
                case 4:
                    text = Number.Four.ToString();
                    break;
                case 5:
                    text = Number.Five.ToString();
                    break;
                case 6:
                    text = Number.Six.ToString();
                    break;
                case 7:
                    text = Number.Seven.ToString();
                    break;
                case 8:
                    text = Number.Eight.ToString();
                    break;
                case 9:
                    text = Number.Nine.ToString();
                    break;
                case 10:
                    text = Number.Ten.ToString();
                    break;
                default:
                    text = string.Empty;
                    break;
            }

            return text;
        }

        private static string GetNumberText2(decimal number)
        {
            string text = string.Empty;

            switch ((int)number) {
                case 0:
                    text = Number.Zero.ToString();
                    break;
                case 1:
                    text = Number.One.ToString();
                    break;
                case 2:
                    text = Number.Two.ToString();
                    break;
                case 3:
                    text = Number.Three.ToString();
                    break;
                case 4:
                    text = Number.Four.ToString();
                    break;
                case 5:
                    text = Number.Five.ToString();
                    break;
                case 6:
                    text = Number.Six.ToString();
                    break;
                case 7:
                    text = Number.Seven.ToString();
                    break;
                case 8:
                    text = Number.Eight.ToString();
                    break;
                case 9:
                    text = Number.Nine.ToString();
                    break;
                case 10:
                    text = Number.Ten.ToString();
                    break;
                default:
                    text = string.Empty;
                    break;
            }

            return text;
        }

        private static string GetNumberText3(int number)
        {
            string text = string.Empty;

            switch (number) {
                case 0:
                    text = Number.Zero.ToString();
                    break;
                case 1:
                    text = Number.One.ToString();
                    break;
                case 2:
                    text = Number.Two.ToString();
                    break;
                case 3:
                    text = Number.Three.ToString();
                    break;
                case 4:
                    text = Number.Four.ToString();
                    break;
                case 5:
                    text = Number.Five.ToString();
                    break;
                case 6:
                    text = Number.Six.ToString();
                    break;
                case 7:
                    text = Number.Seven.ToString();
                    break;
                case 8:
                    text = Number.Eight.ToString();
                    break;
                case 9:
                    text = Number.Nine.ToString();
                    break;
                case 10:
                    text = Number.Ten.ToString();
                    break;
                default:
                    text = string.Empty;
                    break;
            }

            return text;
        }
    }
}
