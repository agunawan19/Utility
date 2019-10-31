Imports System.Data.SqlClient
Imports UtilityLibraries

Module Module1
    Private Property Connection As SqlConnection

    Sub Main()
        ConnectToDatabase()
        Dim productTable As DataTable = GetData()

        DataTableTest()
    End Sub

    Sub ReportLibraryTest()
        Dim util As New ReportLibrary()
        Const title As String = "Utilitiy Test"
        Console.WriteLine(title)
    End Sub

    Sub ConnectToDatabase()
        Dim connectionString As String = GetConnectionString()
        Connection = New SqlConnection(connectionString)
    End Sub

    Private Function GetConnectionString() As String
        Return "Server=RD1014;Database=TestDb;Trusted_Connection=True"
    End Function

    Private Function GetData() As DataTable
        Dim sql As String = GetAllProductsQuery()
        Dim dt As New DataTable()

        Using cmd As New SqlCommand(sql, Connection)
            If Connection.State = ConnectionState.Closed Then
                Connection.Open()
            End If

            Using dataAdapter As New SqlDataAdapter(cmd)
                dataAdapter.Fill(dt)
            End Using

            Connection.Close()
        End Using

        Return dt
    End Function

    Private Function GetAllProductsQuery() As String
        Return "SELECT * FROM Products"
    End Function

    Private Enum Column
        FirstColumn
        SecondColumn
    End Enum

    Sub DataTableTest()
        Dim dt As New DataTable()

        Dim firstColumn As String = Column.FirstColumn.ToString()
        Dim secondColumn As String = Column.SecondColumn.ToString()

        dt.Columns.Add(New DataColumn(firstColumn, GetType(String)))
        dt.Columns.Add(New DataColumn(secondColumn, GetType(Integer)))

        Dim newRow As DataRow = dt.NewRow()
        newRow.SetField(Of String)(firstColumn, Nothing)
        newRow.SetField(Of Integer)(secondColumn, Nothing)
        dt.Rows.Add(newRow)

        newRow = dt.NewRow()
        newRow.SetField(firstColumn, "MyString")
        newRow.SetField(secondColumn, 1)
        dt.Rows.Add(newRow)

        For Each row As DataRow In dt.Rows
            Dim output As String = $"{Convert.ToString(row(firstColumn))}, {Convert.ToString(row(secondColumn))}"
            Console.WriteLine(output)
        Next
    End Sub

End Module
