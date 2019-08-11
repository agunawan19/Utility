Public Class Utility
    Public Function ConvertMemoFieldToDictionary(
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

    Private Function GetFrequencyCaptions(frequency As String) As String
        Dim caption As String = String.Empty

        ' Syssetup.GetSystemSetup("COT" & item.ToString() & "_DESC")

        If frequency = "1" Then
            'caption = GetLocalizedString("ddlNPTOREDFREQ1", "Once Per Pay Period"),
        Else
            'caption = GetLocalizedString("ddlNPTOREDFREQ2", "Once Per Week")
        End If

        Return caption
    End Function

    Private Function GetOvertimeCaption(overtimeLevel As String) As String
        Dim caption As String = String.Empty

        Dim level As Byte = 0

        If Byte.TryParse(overtimeLevel, level) Then
            If overtimeLevel > 0 Then
                caption = $"COT{level}_DESC"
            Else
                caption = "Regular"
            End If
        End If

        Return caption
    End Function

End Class
