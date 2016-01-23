Imports System.IO
Imports System.Drawing.Imaging
Imports System.Configuration
Imports Engine
Imports LinqDB.ConnectDB
Imports System.Threading
Public Class Form1

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        GoStart()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        e.Result = Me.ConvertBinaryToImageFile
        lblPercent.Text = e.Result
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        lblPercent.Text = ProgressBar1.Value & "%"
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        ProgressBar1.Value = 0
        lblPercent.Text = ProgressBar1.Value & "%"
        BackgroundWorker1.Dispose()
        If Not isThreadAlive() Then
            lblPercent.Text = "100%"
            btnStart.Enabled = True
            btnStop.Enabled = False
            'tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        GoStop()
    End Sub

    Private Function ConvertBinaryToImageFile() As String
        Try
            CheckForIllegalCrossThreadCalls = False
            System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

            Dim dt As New DataTable
            Dim sql As String = ""
            sql = "select "
            sql &= " ph.id"
            sql &= " ,ph.tag_no"
            sql &= " ,ph.image_file"
            sql &= " ,ph.file_ext"
            sql &= " ,ph.is_selected"
            sql &= " ,ph.is_post_facebook "
            sql &= " ,replace(r.customer_name_th,' ','_') + '_' + convert(varchar, ROW_NUMBER() OVER(  PARTITION BY r.customer_name_th  ORDER BY ph.id asc))  +  ph.file_ext  as customerfilename"
            sql &= " from tks_take_photo ph "
            sql &= " inner join tks_register r"
            sql &= " on r.tag_no = ph.tag_no"
            sql &= " where is_selected='Y'"
            dt = SqlDB.ExecuteTable(sql)

            Dim count As Integer = 0
            Dim Totalcount As Integer = dt.Rows.Count
            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    Try
                        Dim customerfilename As String = dt.Rows(i)("customerfilename")
                        Dim id As String = dt.Rows(i)("id").ToString
                        If Convert.IsDBNull(dt.Rows(i)("image_file")) = True Then
                            Continue For
                        End If

                        Dim myBytes() As Byte
                        myBytes = DirectCast(dt.Rows(i)("image_file"), Byte())

                        Dim myMemStream As System.IO.MemoryStream = New System.IO.MemoryStream(myBytes)
                        Dim fullsizeImage As System.Drawing.Image = System.Drawing.Image.FromStream(myMemStream)

                        Dim strPath As String = "D:\TKS_PHOTOFILE"
                        If (Not System.IO.Directory.Exists(strPath)) Then
                            System.IO.Directory.CreateDirectory(strPath)
                        End If

                        fullsizeImage.Save(strPath & "\" & customerfilename, System.Drawing.Imaging.ImageFormat.Jpeg)
                        fullsizeImage.Dispose()
                        count += 1
                        BackgroundWorker1.ReportProgress(Math.Floor(count * 100 / Totalcount))
                        Threading.Thread.Sleep(5)
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                    End Try

                Next

            End If
            'FinalDestination:
            Return "End"
        Catch ex As Exception
            Return "Error"
        End Try

    End Function

    Private Function isThreadAlive() As Boolean
        Return BackgroundWorker1.IsBusy
    End Function

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

   
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        GoStart()
    End Sub

    Private Sub GoStart()
        Timer1.Enabled = True
        btnStart.Enabled = False
        btnStop.Enabled = True
        If (Not BackgroundWorker1.IsBusy) Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub GoStop()
        Timer1.Enabled = False
        If Not BackgroundWorker1.CancellationPending Then
            Try
                BackgroundWorker1.CancelAsync()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GoStart()
    End Sub
End Class

