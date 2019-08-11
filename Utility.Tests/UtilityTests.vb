Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility.Utility
Imports Telerik.JustMock

<TestClass()> Public Class UtilityTests

    <TestMethod()> Public Sub ConvertMemoFieldToDictionaryShouldReturnCorrectResult()
        Dim utility As New Utility()
        Dim memo As String = $"FIELD1=.T.{vbCrLf}FIELD2=0{vbCrLf}FIELD3={vbLf}FIELD4=100{vbCrLf}FIELD5=ABC"
        Dim delimiters As String() = {vbCrLf, vbLf}

        Dim expected As New Dictionary(Of String, String) From {
            {"FIELD1", ".T."},
            {"FIELD2", "0"},
            {"FIELD3", ""},
            {"FIELD4", "100"},
            {"FIELD5", "ABC"}
        }
        Dim actual As Dictionary(Of String, String) = utility.ConvertMemoFieldToDictionary(memo, delimiters)

        CollectionAssert.AreEqual(expected, actual)

        Dim includedFields As New HashSet(Of String) From {
            "FIELD2", "FIELD4"
        }
        expected = New Dictionary(Of String, String) From {
            {"FIELD2", "0"},
            {"FIELD4", "100"}
        }
        actual = utility.ConvertMemoFieldToDictionary(memo, delimiters, includedFields)

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    <TestMethod()> Public Sub ConvertMemoFieldToDictionaryShouldReturnEmptyDictionary()
        Dim utility As New Utility()
        Dim memo As String = String.Empty
        Dim delimiters As String() = {";"}

        Dim expected As New Dictionary(Of String, String)()
        Dim actual As Dictionary(Of String, String) = utility.ConvertMemoFieldToDictionary(memo, delimiters)

        CollectionAssert.AreEqual(expected, actual)
    End Sub

End Class