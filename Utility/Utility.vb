﻿Public Class Utility
    Public Function ConvertMemoFieldsToDictionary(
        text As String,
        delimiters As String(),
        Optional includedColumns As HashSet(Of String) = Nothing) As Dictionary(Of String, String)
        Dim keyValuePairs As New Dictionary(Of String, String)()
        Dim pairs As String() = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
        Dim isIncludedColumn As Boolean = True

        For Each pair As String In pairs
            Dim kvp As String() = pair.Split("=")

            If includedColumns IsNot Nothing Then
                isIncludedColumn = includedColumns.Contains(kvp(0))
            End If

            If isIncludedColumn Then
                keyValuePairs(kvp(0)) = kvp(1)
            End If

            If includedColumns IsNot Nothing Then
                If keyValuePairs.Count = includedColumns.Count Then
                    Exit For
                End If
            End If
        Next

        Return keyValuePairs
    End Function
End Class
