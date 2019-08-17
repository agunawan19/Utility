using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CommonUtilities.Tests
{
    [TestClass()]
    public class ExtensionsTests : ExtensionsTestsBase
    {
        [DataTestMethod()]
        [DataRow(true, 10, 1, 10)]
        [DataRow(true, 1, 1, 10)]
        [DataRow(true, 5, 1, 10)]
        [DataRow(false, 0, 1, 10)]
        [DataRow(false, 11, 1, 10)]
        [DataRow(true, -10, -10, 1)]
        [DataRow(true, 1, -10, 1)]
        [DataRow(false, -11, -10, 1)]
        [DataRow(false, 2, -10, 1)]
        public void IsBetweenIntegerTest(bool expected, int value, int lowerBound, int upperBound)
        {
            bool actual = value.IsBetween(lowerBound, upperBound);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod()]
        [DataRow(true, "10.00", "1", "10")]
        [DataRow(true, "1.00", "1", "10")]
        [DataRow(true, "5.01", "1", "10")]
        [DataRow(false, "0.99999", "1", "10")]
        [DataRow(false, "10.001", "1", "10")]
        [DataRow(true, "-5.55", "-5.55", "1.25")]
        [DataRow(true, "1.25", "-5.55", "1.25")]
        [DataRow(false, "-5.56", "-5.55", "1.25")]
        [DataRow(false, "1.26", "-5.55", "1.25")]
        public void IsBetweenDecimalTest(bool expected, string value, string lowerBound, string upperBound)
        {
            decimal decimalValue = Convert.ToDecimal(value);
            decimal decimalLowerBound = Convert.ToDecimal(lowerBound);
            decimal decimalUpperBound = Convert.ToDecimal(upperBound);
            bool actual = decimalValue.IsBetween(decimalLowerBound, decimalUpperBound);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod()]
        [DataRow(true, 9, 1, 10)]
        [DataRow(true, 2, 1, 10)]
        [DataRow(true, 5, 1, 10)]
        [DataRow(false, 1, 1, 10)]
        [DataRow(false, 10, 1, 10)]
        [DataRow(true, -2, -10, 5)]
        [DataRow(false, -10, -10, 5)]
        [DataRow(false, 5, -10, 5)]
        public void IsBetweenExcludeEqualIntegerTest(bool expected, int value, int lowerBound, int upperBound)
        {
            bool actual = value.IsBetween(lowerBound, upperBound, isEqualIncluded: false);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod()]
        [DataRow(true, "2019-01-01", "2019-01-01", "2019-12-31")]
        [DataRow(true, "2019-12-31", "2019-01-01", "2019-12-31")]
        [DataRow(false, "2018-01-01", "2019-01-01", "2019-12-31")]
        [DataRow(false, "2020-12-31", "2019-01-01", "2019-12-31")]
        public void IsBetweenDateTest(bool expected, string value, string lowerBound, string upperBound)
        {
            const string dateFormat = "yyyy-MM-dd";
            DateTime dateValue = DateTime.ParseExact(value, dateFormat, null);
            DateTime dateLowerBound = DateTime.ParseExact(lowerBound, dateFormat, null);
            DateTime dateUpperBound = DateTime.ParseExact(upperBound, dateFormat, null);
            bool actual = dateValue.IsBetween(dateLowerBound, dateUpperBound);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod()]
        [DataRow(true, "2019-01-01 00:00:00", "2019-01-01 00:00:00", "2019-12-31 23:59:59")]
        [DataRow(true, "2019-12-31 23:59:59", "2019-01-01 00:00:00", "2019-12-31 23:59:59")]
        [DataRow(false, "2018-12-31 23:59:59", "2019-01-01 00:00:00", "2019-12-31 23:59:59")]
        [DataRow(false, "2020-01-01 00:00:00", "2019-01-01 00:00:00", "2019-12-31 23:59:59")]
        public void IsBetweenDateTimeTest(bool expected, string value, string lowerBound, string upperBound)
        {
            const string dateFormat = "yyyy-MM-dd HH:mm:ss";
            DateTime dateValue = DateTime.ParseExact(value, dateFormat, null);
            DateTime dateLowerBound = DateTime.ParseExact(lowerBound, dateFormat, null);
            DateTime dateUpperBound = DateTime.ParseExact(upperBound, dateFormat, null);
            bool actual = dateValue.IsBetween(dateLowerBound, dateUpperBound);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod()]
        [DataRow(true, "2019-01-02", "2019-01-01", "2019-12-31")]
        [DataRow(false, "2019-01-01", "2019-01-01", "2019-12-31")]
        [DataRow(false, "2019-12-31", "2019-01-01", "2019-12-31")]
        [DataRow(false, "2018-01-01", "2019-01-01", "2019-12-31")]
        [DataRow(false, "2020-12-31", "2019-01-01", "2019-12-31")]
        public void IsBetweenDateExcludeEqualTest(bool expected, string value, string lowerBound, string upperBound)
        {
            const string dateFormat = "yyyy-MM-dd";
            DateTime dateValue = DateTime.ParseExact(value, dateFormat, null);
            DateTime dateLowerBound = DateTime.ParseExact(lowerBound, dateFormat, null);
            DateTime dateUpperBound = DateTime.ParseExact(upperBound, dateFormat, null);
            bool actual = dateValue.IsBetween(dateLowerBound, dateUpperBound, isEqualIncluded: false);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod()]
        [DataRow(true, "2019-01-01 00:00:01", "2019-01-01 00:00:00", "2019-12-31 23:59:59")]
        [DataRow(false, "2019-01-01 00:00:00", "2019-01-01 00:00:00", "2019-12-31 23:59:59")]
        [DataRow(false, "2019-12-31 23:59:59", "2019-01-01 00:00:00", "2019-12-31 23:59:59")]
        [DataRow(false, "2018-12-31 23:59:59", "2019-01-01 00:00:00", "2019-12-31 23:59:59")]
        [DataRow(false, "2020-01-01 00:00:00", "2019-01-01 00:00:00", "2019-12-31 23:59:59")]
        public void IsBetweenDateTimeExcludeEqualTest(bool expected, string value, string lowerBound, string upperBound)
        {
            const string dateFormat = "yyyy-MM-dd HH:mm:ss";
            DateTime dateValue = DateTime.ParseExact(value, dateFormat, null);
            DateTime dateLowerBound = DateTime.ParseExact(lowerBound, dateFormat, null);
            DateTime dateUpperBound = DateTime.ParseExact(upperBound, dateFormat, null);
            bool actual = dateValue.IsBetween(dateLowerBound, dateUpperBound, isEqualIncluded: false);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod()]
        [DataRow(true, 10.0010, 1, 10.001)]
        [DataRow(true, 1.12340, 1.1234, 10)]
        [DataRow(true, 5.123, 1.1123, 10.123)]
        [DataRow(false, 0.099901, 0.9999, 10)]
        [DataRow(false, 10.000101, 1, 10.0001)]
        [DataRow(true, -10.0010, -10.001, 1)]
        [DataRow(true, 1.0001, -10, 1.0001)]
        [DataRow(false, -10.000101, -10.0001, 1)]
        [DataRow(false, 1.000101, -10, 1.0001)]
        public void IsBetweenDoubleTest(bool expected, double value, double lowerBound, double upperBound)
        {
            bool actual = value.IsBetween(lowerBound, upperBound);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod()]
        [DataRow(true, 10.001f, 1f, 10.001f)]
        [DataRow(true, 1.1234f, 1.1234f, 10f)]
        [DataRow(true, 5.123f, 1.1123f, 10.123f)]
        [DataRow(false, 0.0998f, 0.9999f, 10f)]
        [DataRow(false, 10.0002f, 1f, 10.0001f)]
        [DataRow(true, -10.001f, -10.001f, 1f)]
        [DataRow(true, 1.0001f, -10f, 1.0001f)]
        [DataRow(false, -10.0002f, -10.0001f, 1f)]
        [DataRow(false, 1.0002f, -10f, 1.0001f)]
        public void IsBetweenFloatTest(bool expected, float value, float lowerBound, float upperBound)
        {
            bool actual = value.IsBetween(lowerBound, upperBound);

            Assert.AreEqual(expected, actual);
        }
    }
}