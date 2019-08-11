Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Utility.Utility

<TestClass()> Public Class UtilityTests

    <TestMethod()> Public Sub ConvertMemoFieldToDictionaryShouldReturnCorrectResult()
        Dim utility As New Utility()
        Dim memo As String = $"FIELD1=.T.;FIELD2=0;FIELD3=,FIELD4=100"
        Dim delimiters As String() = {";", ","}
        Dim includedFields As New HashSet(Of String) From {
            "FIELD2", "FIELD3"
        }

        Dim actual As Dictionary(Of String, String) = utility.ConvertMemoFieldToDictionary(memo, delimiters)
        Dim expected As Dictionary(Of String, String) = New Dictionary(Of String, String) From {
            {"FIELD1", ".T."},
            {"FIELD2", "0"},
            {"FIELD3", ""},
            {"FIELD4", "100"}
        }

        CollectionAssert.AreEqual(expected, actual)

        actual = utility.ConvertMemoFieldToDictionary(memo, delimiters, includedFields)
        expected = New Dictionary(Of String, String) From {
            {"FIELD2", "0"},
            {"FIELD3", ""}
        }

        CollectionAssert.AreEqual(expected, actual)
    End Sub

    <TestMethod()> Public Sub ConvertMemoFieldToDictionaryShouldReturnEmptyDictionary()
        Dim utility As New Utility()
        Dim memo As String = ""
        Dim delimiters As String() = {";"}

        Dim actual As Dictionary(Of String, String) = utility.ConvertMemoFieldToDictionary(memo, delimiters)
        Dim expected As New Dictionary(Of String, String)()

        CollectionAssert.AreEqual(expected, actual)
    End Sub
End Class