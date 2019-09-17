Namespace UtilityLibraries
    Public Class ReportLibrary
        Implements IReportLibrary
        Public Function GetDictionaryFromMemoField(
            text As String,
            delimiters As String(),
            Optional includedFields As HashSet(Of String) = Nothing) As Dictionary(Of String, String) Implements IReportLibrary.GetDictionaryFromMemoField
            Dim keyValuePairs As New Dictionary(Of String, String)()
            Dim pairs As String() = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            Dim isIncludedField As Boolean = True

            For Each pair As String In pairs
                Dim kvp As String() = pair.Split("=")

                If includedFields IsNot Nothing Then
                    isIncludedField = includedFields.Contains(kvp(0))
                End If

                If isIncludedField Then
                    keyValuePairs(kvp(0)) = kvp(1)
                End If

                If includedFields IsNot Nothing Then
                    If keyValuePairs.Count = includedFields.Count Then
                        Exit For
                    End If
                End If
            Next

            Return keyValuePairs
        End Function

        Public Function GetFrequencyCaptions(frequency As String) As String Implements IReportLibrary.GetFrequencyCaptions
            Dim caption As String = String.Empty

            ' Syssetup.GetSystemSetup("COT" & item.ToString() & "_DESC")

            If frequency = "1" Then
                'caption = GetLocalizedString("ddlNPTOREDFREQ1", "Once Per Pay Period"),
            Else
                'caption = GetLocalizedString("ddlNPTOREDFREQ2", "Once Per Week")
            End If

            Return caption
        End Function

        Public Function GetOvertimeCaption(overtimeLevel As String) As String Implements IReportLibrary.GetOvertimeCaption
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

        Public Function FormatSSN(text As String, format As String, isMasked As Boolean) As String Implements IReportLibrary.FormatSSN
            If String.IsNullOrWhiteSpace(text) Then
                Return String.Empty
            End If

            Const maskedChar As Char = "*"
            Dim nonReplaceableChars As New HashSet(Of Char)("#%()*,- ".ToCharArray())

            format = format.Aggregate(
                (New List(Of Char), 0S),
                Function(accumulator As (CharList As List(Of Char), CharIndex As Short), currentChar As Char)
                    If nonReplaceableChars.Contains(currentChar) Then
                        accumulator.CharList.Add(currentChar)
                    Else
                        If accumulator.CharIndex < text.Length Then
                            currentChar = If(Not isMasked, text(accumulator.CharIndex), maskedChar)
                            accumulator.CharList.Add(currentChar)
                            accumulator.CharIndex += 1
                        End If
                    End If

                    Return accumulator
                End Function,
                Function(result As (CharList As List(Of Char), CharIndex As Short))
                    Return result.CharList.ToArray()
                End Function)

            Return format
        End Function

    End Class

End Namespace
