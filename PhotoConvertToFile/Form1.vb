Public Class Form1

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        btnStart.Enabled = False
        btnStop.Enabled = True
        If (Not BackgroundWorker1.IsBusy) Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        e.Result = Me.ConvertBinaryToImagefile
        lblPercent.Text = e.Result
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        lblPercent.Text = ProgressBar1.Value & "%"
    End Sub
    'Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    '    ProgressBar1.Value = 0
    '    lblPercent.Text = ProgressBar1.Value & "%"
    '    BackgroundWorker1.Dispose()
    '    If Not isThreadAlive() Then
    '        lblPercent.Text = "End"
    '        'tlActive.Image = frmMain.imgLst.Images("noActivity")
    '    End If
    'End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If Not BackgroundWorker1.CancellationPending Then
            Try
                BackgroundWorker1.CancelAsync()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Function ConvertBinaryToImagefile() As String
        Dim count As Integer
        Dim Totalcount As Integer = 100
        For i As Integer = 1 To 100
            count += 1
            BackgroundWorker1.ReportProgress(Math.Floor(count * 100 / Totalcount))
            Threading.Thread.Sleep(5)
        Next

        Return "End"
    End Function
End Class
