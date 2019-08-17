Imports System.Runtime.CompilerServices


Module Extensions
    <Extension()>
    Public Function IsBetween(Of T As {Structure, IComparable, IComparable(Of T), IConvertible, IEquatable(Of T), IFormattable})(value As T, lowerBound As T, upperBound As T) As Boolean
        Return value.CompareTo(lowerBound) >= 0 AndAlso value.CompareTo(upperBound) <= 0
    End Function

    <Extension()>
    Public Sub PrintAndPunctuate(aString As String, punc As String)
        Console.WriteLine(aString & punc)
    End Sub
End Module
