Imports OfficeOpenXml
Imports System.IO
Public Class frmImportCustomerList

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fileName As String = Application.StartupPath & "\K.Siriwan_ALL_FINAL_RFID_452.xlsx"

        Using pck = New OfficeOpenXml.ExcelPackage()
            Try
                Using stream = File.OpenRead(fileName)
                    pck.Load(stream)
                End Using
                Dim ws = pck.Workbook.Worksheets.First()

                Dim dt As New DataTable
                dt.Columns.Add("barcode")
                dt.Columns.Add("OWNER")
                dt.Columns.Add("GROUP")
                dt.Columns.Add("SUB_GROUP")
                dt.Columns.Add("TITLE_NAME")
                dt.Columns.Add("NAME")
                dt.Columns.Add("SURNAME")
                dt.Columns.Add("ADDRESS")
                dt.Columns.Add("POSTCODE")
                dt.Columns.Add("NAME_EN")
                dt.Columns.Add("POSITION")
                dt.Columns.Add("ORGANIZATION")
                dt.Columns.Add("EMAIL")
                dt.Columns.Add("REF1")
                dt.Columns.Add("REF2")

                For r As Integer = 2 To ws.Dimension.[End].Row
                    Dim dr As DataRow = dt.NewRow
                    dr("barcode") = ws.Cells("A" & r).Value
                    dr("OWNER") = ws.Cells("B" & r).Value
                    dr("GROUP") = ws.Cells("C" & r).Value
                    dr("SUB_GROUP") = ws.Cells("D" & r).Value
                    dr("TITLE_NAME") = ws.Cells("E" & r).Value
                    dr("NAME") = ws.Cells("F" & r).Value
                    dr("SURNAME") = ws.Cells("G" & r).Value
                    dr("ADDRESS") = ws.Cells("H" & r).Value
                    dr("POSTCODE") = ws.Cells("I" & r).Value
                    dr("NAME_EN") = ws.Cells("J" & r).Value
                    dr("POSITION") = ws.Cells("K" & r).Value
                    dr("ORGANIZATION") = ws.Cells("L" & r).Value
                    dr("EMAIL") = ws.Cells("M" & r).Value
                    dr("REF1") = ws.Cells("N" & r).Value
                    dr("REF2") = ws.Cells("O" & r).Value
                    dt.Rows.Add(dr)
                Next

                If dt.Rows.Count > 0 Then
                    Engine.PreRegister.ImportExcelData(dt)
                End If
                MessageBox.Show("Import Complete")
                dt.Dispose()
            Catch ex As Exception

            End Try
        End Using
    End Sub


    Private Function getDataTableFromExcel(path As String) As DataTable
        Using pck = New OfficeOpenXml.ExcelPackage()
            Using stream = File.OpenRead(path)
                pck.Load(stream)
            End Using
            Dim ws = pck.Workbook.Worksheets.First()
            Dim tbl As New DataTable()
            Dim hasHeader As Boolean = True


            For Each firstRowCell As Object In ws.Cells(1, 1, 1, ws.Dimension.[End].Column)
                tbl.Columns.Add(If(hasHeader, firstRowCell.Text, String.Format("Column {0}", firstRowCell.Start.Column)))
            Next
            Dim startRow = If(hasHeader, 2, 1)
            For rowNum As Integer = startRow To ws.Dimension.[End].Row
                Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.[End].Column)
                Dim row = tbl.NewRow()
                For Each cell As Object In wsRow
                    row(cell.Start.Column - 1) = cell.Text
                Next
                tbl.Rows.Add(row)
            Next
            Return tbl
        End Using
    End Function

End Class