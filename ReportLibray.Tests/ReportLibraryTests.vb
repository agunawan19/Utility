Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports UtilityLibraries

<TestClass()> Public Class ReportLibrayTests
    Inherits ReportLibraryTestsBase

    <TestMethod()> Public Sub ConvertMemoFieldToDictionaryShouldReturnCorrectResult()
        Dim memo As String = $"FIELD1=.T.{vbCrLf}FIELD2=0{vbCrLf}FIELD3={vbLf}FIELD4=100{vbCrLf}FIELD5=ABC"
        Dim delimiters As String() = {vbCrLf, vbLf}

        Dim expected As New Dictionary(Of String, String) From
        {
            {"FIELD1", ".T."},
            {"FIELD2", "0"},
            {"FIELD3", ""},
            {"FIELD4", "100"},
            {"FIELD5", "ABC"}
        }
        Dim actual As Dictionary(Of String, String) = ReportLibrary.GetDictionaryFromMemoField(memo, delimiters)

        CollectionAssert.AreEqual(expected, actual)

        Dim includedFields As New HashSet(Of String) From
        {
            "FIELD2", "FIELD4"
        }
        expected = New Dictionary(Of String, String) From
        {
            {"FIELD2", "0"},
            {"FIELD4", "100"}
        }
        actual = ReportLibrary.GetDictionaryFromMemoField(memo, delimiters, includedFields)

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    <TestMethod()> Public Sub ConvertMemoFieldToDictionaryShouldReturnEmptyDictionary()
        Dim memo As String = String.Empty
        Dim delimiters As String() = {";"}

        Dim expected As New Dictionary(Of String, String)()
        Dim actual As Dictionary(Of String, String) = ReportLibrary.GetDictionaryFromMemoField(memo, delimiters)

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    <TestMethod()> Public Sub GetFrequencyCaptionShouldReturnCorrectValue()
        Const caption1 As String = "Once Per Pay Period"
        Const caption2 As String = "Once Per Week"

        MockReportLibrary.Setup(Function(obj) obj.GetFrequencyCaptions("1")).Returns(caption1)
        mockReportLibrary.Setup(Function(obj) obj.GetFrequencyCaptions("2")).Returns(caption2)

        Dim expected1 As String = caption1
        Dim actual1 As String = mockReportLibrary.Object.GetFrequencyCaptions("1")

        Dim expected2 As String = caption2
        Dim actual2 As String = mockReportLibrary.Object.GetFrequencyCaptions("2")

        Assert.AreEqual(expected1, actual1)
        Assert.AreEqual(expected2, actual2)
    End Sub

    <DataTestMethod()>
    <DataRow("123121234", "999-99-9999", False, "123-12-1234")>
    <DataRow("123121234", "999-99-9999", True, "***-**-****")>
    <DataRow("123121234", "(999) (99)*(9999)", False, "(123) (12)*(1234)")>
    <DataRow("123121234", "(999) (99)*(9999)", True, "(***) (**)*(****)")>
    <DataRow("123121234", "%(999) (99)#*(9999)", False, "%(123) (12)#*(1234)")>
    <DataRow("123121234", "%(999) (99)#*(9999)", True, "%(***) (**)#*(****)")>
    <DataRow("12312123", "%($$$) (XX)#*(9999)", False, "%(123) (12)#*(123)")>
    <DataRow("12312123", "%($$$) (XX)#*(9999)", True, "%(***) (**)#*(***)")>
    <DataRow("123121234", "99-99-9999", False, "12-31-2123")>
    <DataRow("123121234", "99-99-9999", True, "**-**-****")>
    <DataRow("1231212", "999-99-9999", False, "123-12-12")>
    <DataRow("1231212", "999-99-9999", True, "***-**-**")>
    <DataRow("12", "999-99-9999", False, "12--")>
    <DataRow("12", "999-99-9999", True, "**--")>
    <DataRow("", "999-99-9999", False, "")>
    <DataRow("", "999-99-9999", True, "")>
    Public Sub SSNFormatTestShouldReturnFormattedNumber(text As String, format As String, isMasked As Boolean, expected As String)
        Dim actual As String = ReportLibrary.FormatSSN(text, format, isMasked)

        Assert.AreEqual(expected, actual)
    End Sub
End Class