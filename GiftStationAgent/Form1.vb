Imports Engine
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.IO
Imports System.Text

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        GoStart()
    End Sub

    Private Sub GoStart()
        Timer1.Enabled = True
        btnStart.Enabled = False
        btnStop.Enabled = True
        Dim strSQL As String = ""

        strSQL = " select"
        'strSQL &= " ROW_NUMBER() OVER(ORDER BY register_time asc) AS rownumber  "
        strSQL &= " r.customer_name_th"
        ' strSQL &= " ,r.position_name"
        strSQL &= " ,r.company_name"
        strSQL &= " ,(case when  r.current_station_no ='5' then '0' else '1' end ) as IsStatus"
        strSQL &= " from tks_register  r "
        strSQL &= " where r.register_time Is Not null  and r.current_station_no in ('5','6')"
        strSQL &= " order by register_time asc"
        Dim dt As DataTable = SqlDB.ExecuteTable(strSQL)

        Dim result As New StringBuilder
        For i As Integer = 0 To dt.Rows.Count - 1

            For j As Integer = 0 To dt.Columns.Count - 1
                Dim columname As String = dt.Columns(j).ColumnName
                result.Append(dt.Rows(i)(columname).ToString())
                If j <> dt.Columns.Count - 1 Then
                    result.Append(",")
                End If
                'If j = dt.Columns.Count - 1 Then
                '    'result.Append("\n")
                'Else
                '    result.Append(",")
                'End If
            Next
            result.AppendLine()
        Next

        'Delete
        'Dim FileToDelete As String

        'FileToDelete = "D:\\GiftStationAgent.txt"

        'If System.IO.File.Exists(FileToDelete) = True Then
        '    System.IO.File.Delete(FileToDelete)

        'End If

        'Write
        Dim ojbWriter As New StreamWriter("D:\\GiftStationAgent.txt", False)
        ojbWriter.WriteLine(result.ToString)
        ojbWriter.Close()
    End Sub

    Private Sub GoStop()
        btnStart.Enabled = True
        btnStop.Enabled = False
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GoStart()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        GoStop()
    End Sub
End Class
