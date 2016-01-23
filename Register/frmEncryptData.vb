Public Class frmEncryptData

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtSourceText.Text.Trim <> "" Then '
            txtEncryptText.Text = LinqDB.ConnectDB.SqlDB.EnCripPwd(txtSourceText.Text)
        End If

    End Sub
End Class