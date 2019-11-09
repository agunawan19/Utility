using System;

namespace FizzBuzz.Library
{
    public class FizzBuzzer
    {
        public static string GetValue(int input)
        {
            const int fizzDivisor = 3;
            const int buzzDivisor = 5;
            const string fizzWord = "Fizz";
            const string buzzWord = "Buzz";
            string output = string.Empty;

            //if (input % fizzDivisor == 0 && input % buzzDivisor == 0)
            //{
            //    return fizzWord + buzzWord;
            //}

            //if (input % fizzDivisor == 0)
            //{
            //    return fizzWord;
            //}

            //if (input % buzzDivisor == 0)
            //{
            //    return buzzWord;
            //}

            if (input % fizzDivisor == 0)
            {
                output += fizzWord;
            }

            if (input % buzzDivisor == 0)
            {
                output += buzzWord;
            }

            if (string.IsNullOrEmpty(output))
            {
                output = input.ToString();
            }

            return output;
        }
    }
}
