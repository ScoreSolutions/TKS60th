Public Class frmSearchName

    Public Property Barcode As String

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchData()
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SearchData()
        Dim wh As String = ""
        If txtFullName.Text.Trim <> "" Then
            wh += " and customer_name_th like '%" & txtFullName.Text.Trim & "%'"
        End If
        If txtCompanyName.Text.Trim <> "" Then
            wh += " and company_name like '%" & txtCompanyName.Text.Trim & "%'"
        End If

        Dim dt As DataTable = Engine.Register.GetRegisterData(wh)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("no")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = (i + 1)
            Next
        End If
        If dt IsNot Nothing Then
            DataGridView1.AutoGenerateColumns = False
            DataGridView1.DataSource = dt
        Else
            DataGridView1.DataSource = Nothing
        End If
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If DataGridView1.SelectedRows(0).Cells("colBarcode").Value <> "" Then
            Barcode = DataGridView1.SelectedRows(0).Cells("colBarcode").Value.ToString
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub txtFullName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFullName.KeyUp
        SearchData()
    End Sub

    Private Sub txtCompanyName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCompanyName.KeyUp
        SearchData()
    End Sub
End Class