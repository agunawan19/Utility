﻿Namespace UtilityLibraries

    Public Interface IReportLibrary
        Function GetDictionaryFromMemoField(text As String, delimiters() As String, Optional includedColumns As HashSet(Of String) = Nothing) As Dictionary(Of String, String)
        Function GetFrequencyCaptions(frequency As String) As String
        Function GetOvertimeCaption(overtimeLevel As String) As String
        Function FormatSSN(text As String, format As String, isMasked As Boolean) As String
    End Interface

End Namespace