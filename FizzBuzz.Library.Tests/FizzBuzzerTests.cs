using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FizzBuzz.Library.Tests
{
    [TestClass]
    public class FizzBuzzerTests
    {
        //[TestMethod]
        //public void Buzzer_When1_Returns1()
        //{
        //    int input = 1;

        //    string actual = FizzBuzzer.GetValue(input);

        //    Assert.AreEqual("1", actual);
        //}

        //[TestMethod]
        //public void Buzzer_When1_Returns2()
        //{
        //    int input = 2;

        //    string actual = FizzBuzzer.GetValue(input);

        //    Assert.AreEqual("2", actual);
        //}

        [DataRow(1)]
        [DataRow(2)]
        [DataRow(4)]
        [DataRow(8)]
        [DataRow(11)]
        [DataRow(13)]
        [DataRow(14)]
        [DataTestMethod()]
        public void Buzzer_WhenDefault_ReturnsInput(int input)
        {
            string actual = FizzBuzzer.GetValue(input);
            string expected = input.ToString();
            Assert.AreEqual(expected, actual);
        }

        [DataRow(3)]
        [DataRow(6)]
        [DataRow(9)]
        [DataRow(12)]
        [DataTestMethod()]
        public void Buzzer_WhenDiv3_ReturnsFizz(int input)
        {
            string actual = FizzBuzzer.GetValue(input);
            const string expected = "Fizz";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Buzzer_WhenDiv3_ReturnsFizz2()
        {
            string actual1 = FizzBuzzer.GetValue(3);
            string actual2 = FizzBuzzer.GetValue(6);
            string actual3 = FizzBuzzer.GetValue(9);
            const string expected = "Fizz";

            Assert.AreEqual(expected, actual1, "Assert 1");
            Assert.AreEqual(expected, actual2, "Assert 2");
            Assert.AreEqual(expected, actual3, "Assert 3");
        }

        [DataRow(5)]
        [DataRow(10)]
        [DataTestMethod()]
        public void Buzzer_WhenDiv5_ReturnsBuzz(int input)
        {
            string actual = FizzBuzzer.GetValue(input);
            const string expected = "Buzz";
            Assert.AreEqual(expected, actual);
        }

        [DataRow(0)]
        [DataRow(15)]
        [DataTestMethod()]
        public void Buzzer_WhenDiv3AndDiv5_ReturnsFizzBuzz(int input)
        {
            string actual = FizzBuzzer.GetValue(input);
            const string expected = "FizzBuzz";
            Assert.AreEqual(expected, actual);
        }

        [DataRow( 1, "1")]
        [DataRow( 2, "2")]
        [DataRow( 3, "Fizz")]
        [DataRow( 4, "4")]
        [DataRow( 5, "Buzz")]
        [DataRow( 6, "Fizz")]
        [DataRow( 7, "7")]
        [DataRow( 8, "8")]
        [DataRow( 9, "Fizz")]
        [DataRow(10, "Buzz")]
        [DataRow(11, "11")]
        [DataRow(12, "Fizz")]
        [DataRow(13, "13")]
        [DataRow(14, "14")]
        [DataRow(15, "FizzBuzz")]
        [DataRow(16, "16")]
        [DataRow(17, "17")]
        [DataRow(18, "Fizz")]
        [DataTestMethod()]
        public void GivenDataReturnsCorrectOutput(int input, string expected)
        {
            string actual = FizzBuzzer.GetValue(input);
            Assert.AreEqual(expected, actual);
        }

        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        [DataTestMethod()]
        public void DynamicDataTest(string[] expected)
        {
            var actual = new string[] { "", "", "" };
            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new string[] { "a", "b", "c" } };
            //yield return new object[] { new string[] { "d", "e", "f" } };
        }

        private static IEnumerable<object[]> Data
        {
            get
            {
                yield return new object[] { new string[] { "a", "b", "c" } };
                //yield return new object[] { new string[] { "d", "e", "f" } };
            }
        }
    }
}
