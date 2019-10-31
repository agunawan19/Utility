using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CustomEntity;
//using Moq;
using Unity;
using Unity.Resolution;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;
using CommonUtilities;

namespace CommonUtilities.Tests
{
    [TestClass()]
    public class UtilityTests : TestsBase
    {
        private Utility Utility { get; }

        public UtilityTests()
        {
            Utility = new Utility();
        }

        [DataTestMethod()]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "2019/03/31", "2019/09/30", "2019/09/30", DisplayName = "A -> I, #01, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "2019/03/31", "2019/09/25", "2019/09/25", DisplayName = "A -> I, #02, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "2019/03/31", "2019/03/31", "2019/03/31", DisplayName = "A -> I, #03, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "2019/03/31", "          ", "2019/03/31", DisplayName = "A -> I, #04, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "2019/03/31", "2019/10/01", "2019/10/01", DisplayName = "A -> I, #05, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "2019/03/31", "2019/12/31", "2019/12/31", DisplayName = "A -> I, #06, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "          ", "2019/09/30", "2019/09/30", DisplayName = "A -> I, #07, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "          ", "2019/09/25", "2019/09/25", DisplayName = "A -> I, #08, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "          ", "2019/03/31", "2019/03/31", DisplayName = "A -> I, #09, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "          ", "          ", "2019/09/25", DisplayName = "A -> I, #10, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "          ", "2019/10/01", "2019/10/01", DisplayName = "A -> I, #11, Imported Hired >= Imported Termination")]
        [DataRow("A", "I", "2019/01/01", "2019/10/01", "          ", "2019/12/31", "2019/12/31", DisplayName = "A -> I, #12, Imported Hired >= Imported Termination")]

        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "2019/09/30", "2019/09/30", DisplayName = "I -> A, #01, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "2019/09/25", "2019/09/25", DisplayName = "I -> A, #02, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "2019/03/31", "          ", DisplayName = "I -> A, #03, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "          ", "          ", DisplayName = "I -> A, #04, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "2019/10/01", "2019/10/01", DisplayName = "I -> A, #05, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "2019/12/31", "2019/12/31", DisplayName = "I -> A, #06, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "          ", "2019/09/30", DisplayName = "I -> A, #07, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "          ", "2019/09/25", DisplayName = "I -> A, #08, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "          ", "          ", DisplayName = "I -> A, #09, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "          ", "          ", DisplayName = "I -> A, #10, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "          ", "2019/10/01", DisplayName = "I -> A, #11, Imported Hired >= Imported Termination")]
        [DataRow("I", "A", "2019/01/01", "2019/10/01", "2019/03/31", "          ", "2019/12/31", DisplayName = "I -> A, #12, Imported Hired >= Imported Termination")]
        public void GetTerminationDateShouldReturnCorrectDate(
            string existingStatus, string importedStatus,
            string existingHireDate, string importedHireDate,
            string existingTerminationDate, string importedTerminationDate,
            string expectedTerminationDate)
        {
            DateTime today = new DateTime(2019, 9, 25);
            Mock.Arrange(() => DateTime.Today).Returns(today);

            Employee existingEmployeeInfo = GetEmployeeInfo(existingStatus, existingHireDate, existingTerminationDate);
            Employee importedEmployeeInfo = GetEmployeeInfo(importedStatus, importedHireDate, importedTerminationDate);

            DateTime? expected = null;
            if (DateTime.TryParseExact(existingTerminationDate, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate)) {
                expected = parsedDate;
            }

            DateTime? actual = Utility.GetTerminationDate(existingEmployeeInfo, importedEmployeeInfo);

            Assert.AreEqual(expected, actual);
        }

        private Employee GetEmployeeInfo(string status, string hireDate, string terminationDate)
        {
            Employee employeeInfo = new Employee();

            if (!string.IsNullOrWhiteSpace(status)) {
                employeeInfo.Status = status;
            }

            if (!string.IsNullOrWhiteSpace(hireDate)) {
                var (year, month, day) = SplitDateString(hireDate);
                employeeInfo.HireDate = new DateTime(year, month, day);
            }

            if (!string.IsNullOrWhiteSpace(terminationDate)) {
                var (year, month, day) = SplitDateString(terminationDate);
                employeeInfo.TerminationDate = new DateTime(year, month, day);
            }

            return employeeInfo;
        }

        private (ushort Year, byte Month, byte Day) SplitDateString(string date)
        {
            char[] separators = new char[] { '/', '-' };
            string[] parts = date.Split(separators);

            return (Year: ushort.Parse(parts[0]), Month: byte.Parse(parts[1]), Day: byte.Parse(parts[2]));
        }
    }
}