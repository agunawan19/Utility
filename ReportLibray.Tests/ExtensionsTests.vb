Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Runtime.CompilerServices

<TestClass()> Public Class ExtensionsTests
    <DataTestMethod()>
    <DataRow(True, 10, 1, 10)>
    <DataRow(True, 1, 1, 10)>
    <DataRow(True, 5, 1, 10)>
    <DataRow(False, 0, 1, 10)>
    <DataRow(False, 11, 1, 10)>
    Public Sub BetweenIntegerTest(ByVal expected As Boolean, ByVal value As Integer, ByVal lowerBound As Integer, ByVal upperBound As Integer)
        Dim actual As Boolean = value.IsBetween(lowerBound, upperBound)

        Assert.AreEqual(expected, actual)
    End Sub

    <DataTestMethod()>
    <DataRow(True, "10.00", "1", "10")>
    <DataRow(True, "1.00", "1", "10")>
    <DataRow(True, "5.01", "1", "10")>
    <DataRow(False, "0.99999", "1", "10")>
    <DataRow(False, "10.001", "1", "10")>
    Public Sub BetweenDecimalTest(ByVal expected As Boolean, ByVal value As String, ByVal lowerBound As String, ByVal upperBound As String)
        Dim decimalValue As Decimal = Convert.ToDecimal(value)
        Dim decimalLowerBound As Decimal = Convert.ToDecimal(lowerBound)
        Dim decimalUpperBound As Decimal = Convert.ToDecimal(upperBound)
        Dim actual As Boolean = decimalValue.IsBetween(decimalLowerBound, decimalUpperBound)
        Assert.AreEqual(expected, actual)
    End Sub
End Class
